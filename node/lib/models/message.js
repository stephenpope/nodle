/*
	Message Model
*/

 exports.init = function(req){
 	return {
		system: req.header('nodleMachineId'),
		sender: req.header('nodleUserId'),
		sent: req.header('nodleTimestamp'),
		type: req.header('nodleMsgType'),
		body: req.body
	};
};