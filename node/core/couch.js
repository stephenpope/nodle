/*
    Couch communication handler
*/
exports.init = function(params){
    var conn = params.protocol + "://"
        + params.username + ":" + params.password
        + "@" + params.url;
    var nano = require('nano')(conn);
    var nodleRepo = nano.use(params.name);

    nodleRepo.get('rabbit', function(e,b,h){ //get a document
        b.crazy = 'just testing'; //modify a property
        console.log(b);
        nodleRepo.insert(b, function(a,b,c){ //update the document
            console.log(a,b,c);
        });
    });
//
//    nodleRepo.insert({crazy: false}, "rabbit", function(e,b,h){
//        if(e) { throw e; }
//        console.log("you have inserted the rabbit.")
//      });
};