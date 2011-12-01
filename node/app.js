/*
    The main application.
    Creates Express server and initialises application components
 */  
var express = require('express'),
	app = module.exports = express.createServer(),
  couchParams = {
    protocol: process.env.couchProtocol,
    url: process.env.couchUrl,
    name: process.env.couchDb,
    username: process.env.couchUsername,
    password: process.env.couchPassword
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
  
var io = require('./core/socket').init(app),
  nano = require('./core/couch').init(couchParams);

//init routes modules
require('./core/routes').init(app, nano, io, __dirname + '/public');

// Running on iisnode so use port from global process (iis defines the port)
app.listen(process.env.PORT);
console.log("Nodle server listening in %s mode", app.settings.env);

