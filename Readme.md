PagaDirect integration sample
https://secure.pagadirect.com/api-docs
M. Verkade / vsi.cw / mitcon.cw
V1.0 - July 2023

Process
•	Create the PagaDirect gateway
•	Init a payment using POST /payments
•	Receive the redirect URL from the created payment transaction 
•	Execute the redirect URL to do the actual payment
•	In the return_url page, check if the payment was successful using GET /payments/{transaction_id}
•	Update your invoice / order with the payment details.

No callback is used...

**************************************************************
Visual Studio 2022
ASP.Net Core 7 Razor
Blazor WASM
Swagger (https://localhost:7037/swagger)

Just compile and run...
Have fun!

