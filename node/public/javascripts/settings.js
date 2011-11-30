/*
    Global settings model
 */
var settings = {
    implement: function(){	
		var args = Array.prototype.slice.call(arguments);
		args.forEach(function(name){		
			if(!this.hasOwnProperty(name)){
				Object.defineProperty(this, name, {
					get: function(){
						var val = localStorage[name];
						if(val){ 
							return JSON.parse(val);
						}
						return null;
					},
					set: function(val){
						localStorage[name] = JSON.stringify(val);
					}
				});
			}
		}, this);
    }
};
// implement settings
settings.implement("connections");