/*
    Socket.io configuration
 */
exports.init = function(app){
	var io = require('socket.io').listen(app);

	// io.set('transports', [
	// 	'websocket'
	//   , 'flashsocket'
	//   , 'htmlfile'
	//   , 'xhr-polling'
	//   , 'jsonp-polling'
	//   ]);
	//wire up clients on connect
	io.sockets.on('connection', function(client){
		client.send(JSON.stringify({message: "You're connected"}));

		client.on('message', function(message){
			io.sockets.send(JSON.stringify(message));
		});
	});

	function send(message, callback){
		console.log('sending client message');
		io.sockets.send(JSON.stringify(message));
		callback();
	}

	return {send: send};
};