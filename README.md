# C# .NET Core Computer Probe
This is a very simple computer probe for companies to gain information about employee's machines or servers. It requires SQL Sever, obviously customizable. There are no checks in the BL for validation if the data already exists, so every time the probe runs, it will populate the same data. This can be good or bad depending on your reporting needs, for example the data someone uninstalled some software.

Essentially you would add a username and password to appsettings and build the project. If you wanted to use an installer you could, if you want to manually install this somewhere on the user's computer you can. Ideally you want this on a task that will run mid-day when the computer is most likely on on a 24 hour cycle depending on your needs. This application will gather the following machine information:

* Computer name and user name
* Internal and external IPs
* All installed software
* NICs
* Printers
* GPU's
* Hard drives
* Processors
* OS information

This implementation works only with WINDOWS. Maybe in the future there can be an implementation for Linux and a Xamarin Forms application for IOS and Android.
