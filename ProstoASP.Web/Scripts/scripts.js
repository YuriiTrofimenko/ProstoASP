$(document).ready(function() {
	
	$.getScript("bootstrap/bootstrap.min.js", function(){
	
	   console.log("bootstrap loaded");
	   $.getScript("hogan/hogan-3.0.2.min.js", function(){
			
		   console.log("hogan loaded");
		   $.getScript("jquery/jquery-hashchange.js", function(){
				
			   console.log("jquery-hashchange loaded");
			   $.getScript("app.js", function(){
					
				   console.log("app loaded");
				   $.getScript("custom.js", function(){
						
					   console.log("custom loaded");
					
					});
				});
			});
		});
	});
});