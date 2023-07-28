using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using SAAR3.Server.Helpers;
using Microsoft.AspNetCore.Authorization;
using PagaDirect.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace PagaDirect.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]

    public class PagaDirectController : Controller
    {

        private PagaDirectGateway? _pagaDirectGateway;


        public PagaDirectController()
        {
            // The gateway should be initilized here and not in the endpoints so you can get the key from internal routines in stead of a parameter
        }

        [HttpPost("InitiatePayment")]
        public async Task<IActionResult> InitiatePayment([FromBody] PagaDirectPaymentDataModel pagaDirectPaymentData)
        {
            string sErrorText = string.Empty;

            try
            {
                // The gateway should not be initialised here but in the Class definition
                _pagaDirectGateway = new PagaDirectGateway(pagaDirectPaymentData.PagaDirectApiKey, pagaDirectPaymentData.PagaDirectEndpoint);

                var response = await _pagaDirectGateway.InitiatePayment(pagaDirectPaymentData.Amount, pagaDirectPaymentData.Reference, pagaDirectPaymentData.ReturnUrl);

                // Handle response
                if (response.IsSuccessStatusCode)
                {
                    // Get the response content
                    PagaDirectPaymentResultModel? pagaDirectPaymentResult = await response.Content.ReadFromJsonAsync<PagaDirectPaymentResultModel>();

                    // Check if we created the payment request correctly...
                    if (pagaDirectPaymentResult != null)
                    {
                        return Ok(pagaDirectPaymentResult);
                    }
                }
                else
                {
                    // If the payment fails, you can return an error message to the user
                    sErrorText = "PagaDirect payment failed!";
                }
            }
            catch (Exception ex)
            {
                sErrorText = $"PagaDirect gateway failed when initialising a payment!{Environment.NewLine}{ex.Message}";
            }

            // Return
            return StatusCode(StatusCodes.Status500InternalServerError, $"{sErrorText}");
        }

        /// <summary>
        /// Remark: This is not safe. This should be done with body-parameters
        /// </summary>
        /// <param name="TransActionId"></param>
        /// <param name="PagaDirectApiKey"></param>
        /// <param name="PagaDirectEndpoint"></param>
        /// <returns></returns>
        [HttpGet("GetTransaction/{TransActionId}/{PagaDirectApiKey}/{PagaDirectEndpoint}")]
        public async Task<IActionResult> GetTransaction(string TransActionId, string PagaDirectApiKey, string PagaDirectEndpoint)
        {
            string sErrorText = string.Empty;

            try
            {
                PagaDirectApiKey = PagaDirectApiKey.Replace("~", "/");
                PagaDirectEndpoint = PagaDirectEndpoint.Replace("~", "/");

                // The gateway should not be initialised here but in the Class definition so you avoid having the key as a parameter
                _pagaDirectGateway = new PagaDirectGateway(PagaDirectApiKey, PagaDirectEndpoint);
                var response = await _pagaDirectGateway.GetTransaction(TransActionId);

                // Handle response
                if (response.IsSuccessStatusCode)
                {
                    // Get the response content
                    PagaDirectTransactionModel? pagaDirectTransaction = await response.Content.ReadFromJsonAsync<PagaDirectTransactionModel>();

                    // Check if we created the payment request correctly...
                    if (pagaDirectTransaction != null)
                    {
                        return Ok(pagaDirectTransaction);
                    }
                    else
                    {
                        // If the payment fails, you can return an error message to the user
                        sErrorText = "PagaDirect transaction not found!";
                    }
                }
                else
                {
                    // If the payment fails, you can return an error message to the user
                    sErrorText = "Could not get PagaDirect transaction!";
                }
            }
            catch (Exception ex)
            {
                sErrorText = $"PagaDirect gateway failed when getting transaction!{Environment.NewLine}{ex.Message}";
            }

            // Return
            return StatusCode(StatusCodes.Status500InternalServerError, $"{sErrorText}");
        }


        [HttpGet("GetTransaction")]
        public async Task<String> GetTransaction()
        {
            return "Test 123";
        }

    }

}