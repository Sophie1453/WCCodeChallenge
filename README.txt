This is an ASP.NET Core project built on Razor Pages to display weather data from supplied location.

As it is an IIS based project, to deploy it you will need an IIS server with the aspNetCore module installed. In the IIS server manager, import the Razor_Form_Submit.zip folder with default settings and the page will be hosted on your IIS machine.

The program will look for WeatherAPIKey environment variable in process, user, and machine variables. If it is not found it defaults to supplying my API key to ease deployment/setup. 

Alternatively, open the solution file in Visual Studio and click the run button to lanch the IIS express server as configured for development settings in the project. A browser window should open you directly to the server home page.

To address potential pitfalls in project deployment, I am also currently hosting the Razor_Form_Submit.zip on my personal IIS server which can be located at http://TMcLan.net (it's currently hosted as the default page, I do not have SSL certificates available for my domain to provide one to host it via https).

The project has HTTPS redirection and HSTS requirements disabled to prevent any pitfalls in deployment since this is a toy project. 

If you have any questions feel free to contact me.
