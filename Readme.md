PagaDirect integration sample <br />
https://secure.pagadirect.com/api-docs <br />
Author: M. Verkade / marc@mitcon.cw <br />
<br />
Process <br />
�	Create the PagaDirect gateway <br />
�	Init a payment using POST /payments <br />
�	Receive the redirect URL from the created payment transaction  <br />
�	Execute the redirect URL to do the actual payment <br />
�	In the return_url page, check if the payment was successful using GET /payments/{transaction_id} <br />
�	Update your invoice / order with the payment details. <br />
 <br />
No callback is used... <br />
 <br /><br />
************************************************************** <br /><br />
Visual Studio 2022 <br />
ASP.Net Core 7 Razor <br />
Blazor WASM <br />
Swagger (https://localhost:7037/swagger) <br />
 <br />
Just compile and run... <br />
Have fun! <br />
 <br /><br />
************************************************************** <br /><br />
20230727 - V1.0<br />
~ Initial version<br />
<br />
20230728 - V1.1 Initial version<br />
~ Added payment methods<br />
~ Some visual updates<br />
~ Changed way to call external payment page (old version hanged the app)<br />
<br />



