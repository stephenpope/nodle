/*
    Couch communication handler
*/
exports.init = function(params){
    var accessor = { channels: []};
    var conn = params.protocol + "://"
        + params.username + ":" + params.password
        + "@" + params.url;
    var nano = require('nano')(conn);
    
    //build the channel cache
    nano.db.list(function(err, body, headers){
        if(err){throw err;}
        accessor.channels = body;
    });

    //get channel db if not create it
    function getChannelRepo(channel, callback){
        if(accessor.channels[channel]){
            callback(nano.use(channel));
        } else {
            nano.db.create(channel, function(){
                accessor.channels.push(channel);
                callback(nano.use(channel));
            });   
        }
    };

    //publish a message to the store
    function storeContent(channel, id, content, callback){
        getChannelRepo(channel, function(repo){
            repo.insert(content, id, function(e,b,h){
                if(e){
                    callback(e);
                    throw e
                };
                callback(b);
            })
        });
    }

    //expose public methods
    accessor.store = storeContent;
    return accessor;
};