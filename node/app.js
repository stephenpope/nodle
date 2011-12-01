/*
    The main application.
    Creates Express server and initialises application components
 */  
var express = require('express'),
	app = module.exports = express.createServer(),
  couchParams = {
    protocol: "https",
    url: "kieranties.cloudant.com",
    name: "nodle",
    username: "kieranties",
    password: "e9WBb4fP"
  };

// Express configuration
app.configure(function(){
  app.set('views', __dirname + '/views'); 
  app.set('view engine', 'jade');
  app.use(express.bodyParser());
  app.use(express.methodOverride());
  app.use(express.static(__dirname + '/public'));
  app.use(app.router);  
});

// Development configuration
app.configure('development', function(){
  app.use(express.errorHandler({ dumpExceptions: true, showStack: true })); 
});
  
// Production configuration
app.configure('production', function(){
  app.use(express.errorHandler()); 
});
  
var io = require('./lib/socket').init(app),
  nano = require('./lib/couch').init(couchParams);

//init routes modules
require('./lib/routes').init(app, nano, io, __dirname + '/public');

// Running on iisnode so use port from global process (iis defines the port)
//app.listen(process.env.PORT);
app.listen(1337,"192.168.0.8");
//console.log("Nodle server listening in %s mode", app.settings.env);

