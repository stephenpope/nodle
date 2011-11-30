Nodle
============

Overview
--------
General details and purpose of the project.

---
## Installation
Installation is pretty quick and painless.  You'll need a few things before you're up and running though.  Install the following in the order listed:

+ [NodeJs for Windows v0.6.3][1] (now with built in <code>npm</code> awesomeness)
+ IIS 7 or [IIS7 Express][2]
+ C++ Redistributable Package: [x86][3] or [x64][4]
+ [IISNode v0.1.10][5]
+ [Url Rewrite Module][6]

###Update <code>path</code>
With node installed it's nice to access directly on the command line.  Update your environment <code>path</code> variable to include:

<code>C:\Program Files\nodejs</code>

**OR** If you're on a 64bit setup:

<code>C:\Program Files {x86)\nodejs</code>

Check all is okay with <code>node -v</code>

###Clone Project
<code>git clone https://github.com/stephenpope/nodle.git</code>

###Install Dependancies
<code> cd nodle

npm install -d
</code>

###Configure IIS
+ Start IIS Manager
+ Create a new site, called what ever you like.
+ Set the physical path property to the cloned nodle\node folder
+ Provide a host name for the binding (you can change the port if you need to)

###Edit Hosts
Open your _hosts_ file found at <code>C:\Windows\System32\drivers\etc\hosts</code> (you may need to open with admin rights).

Add a new line as follows:

<code> 127.0.0.1    &lt;iis binding&gt;



[1]: http://nodejs.org/#download
[2]: http://www.microsoft.com/download/en/details.aspx?id=1038
[3]: http://www.microsoft.com/download/en/details.aspx?id=5555
[4]: http://www.microsoft.com/download/en/details.aspx?id=14632
[5]: https://github.com/tjanczuk/iisnode/downloads
[6]: http://www.iis.net/download/URLRewrite