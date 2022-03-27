
import * as FilterComponent from '../js/FilterComponent.js';
 
 var canvas= "#canvas";
var tools = '<div class="col-md-3"><p class="tools" style="margin-top: 9px;">\
				        <br /><a class="edit-link">Edit<a> | \
						<a class="remove-link">X</a></p> </div>\
						</div > ';

var _formKey = "";
// Set variables 
var _frmProjectId = "";
var _frmFormId = "";
var _frmProjectTitle = "";
var _frmFormTitle = "";
var _hostUrl = "";

$(document).ready(function () {

	var _utility = new Utility();
	_hostUrl = _utility.GetHostUrl();
	 //alert(_hostUrl);
	_frmProjectId = $("#hdnProjectId").val();
	_frmFormId = $("#hdnFormId").val();
	_frmProjectTitle = $("#hdnProjectTitle").val();
	_frmFormTitle = $("#hdnFormTitle").val();


	// form designer setup
	var frmkey = $("#hdnFormKey").val();
	var hdnHasLayout = $("#hdnHasLayout").val();
	
	//set loc.store initial header for empty json doc / db fetched json doc
	SetformToLocalStore(frmkey, hdnHasLayout); 

	// Drag and Drop setup
	setup_draggable(); 
	

		 $(".design-mode").on('click', function() {
			if ($(this).attr("class") == "design-mode") {
				this.src = this.src.replace("-off","-on");
				$('#viewer').toggle(true);
				$('#canvas').toggle(false);
				if (localStorage[_formKey] !=""){
					renderCanvas();
				}
			} else {
				this.src = this.src.replace("-on","-off");
				$('#canvas').toggle(true);
				$('#viewer').toggle(false);
				if (localStorage[_formKey] !=""){
					renderForm();
				}
			}
		  $(this).toggleClass("on");
		  renderForm();
		});
  		 $("#copy-to-storage").on("click",function(){
			
			
		});

		

		$("#open-to-storage").on("click", function(){
			 $('#file-input').trigger('click');
			 
		});
		// File reader on file inout dialog
		 const fileSelector = document.getElementById('file-input');
		  fileSelector.addEventListener('change', (event) => {
			const fileList = event.target.files;
			const reader = new FileReader();
			  reader.addEventListener('load', (event) => {
				const jsonSchema = event.target.result;
				setFormState(JSON.parse(jsonSchema));
				renderCanvas();
			  });
			  reader.readAsText(fileList[0]); 
		 });
		 
		// Save as Json Form Schema Download 
		$("#copy-to-file").on("click", function(){
		    //alert("Save to file call")
			var frmState = JSON.parse(localStorage[_formKey]);
			localStorage[_formKey] = JSON.stringify(frmState);
			downloadSchema(JSON.stringify(frmState,null,4), 'form.json', 'text/plain');
			
		});

	// Save as Json Form to Database 
	$("#save-to-db").on("click", function () {
		var frmState = JSON.parse(localStorage[_formKey]);
		localStorage[_formKey] = JSON.stringify(frmState);
		//downloadSchema(JSON.stringify(frmState, null, 4), 'form.json', 'text/plain');
		// Update form Layout
		var formData = {
			"projectId": _frmProjectId,
			"formId": _frmFormId,
			"layout": localStorage[_formKey] 
		};
		 
		$.ajax({
			url: _hostUrl + "api/Forms/updateformlayout/",
			type: 'post',
			dataType: 'json',
			contentType: 'application/json',
			success: function (response) {
				if (response.success) {
					alert('Updated Form design changes');
				}
				else {
					alert('Error in updating Form design changes');

                }
			},
			data: JSON.stringify(formData)
		});
 
	});
  
	});
	
	var setup_draggable = function() {
		$( ".draggable" ).draggable({
			appendTo: "body",
			helper: "clone"
		});
		$( ".droppable" ).droppable({
			accept: ".draggable",
			helper: "clone",
			hoverClass: "droppable-active",
			drop: function( event, ui ) {
				 
			    //var $modal = get_modal("Some").modal("show");
				$(".empty-form").remove();
				revert: true;
				var this_id = $(ui.draggable).attr("id");
	 			
				var $orig = $(ui.draggable)
				//alert($orig);
				
				if(!$(ui.draggable).hasClass("dropped")) {
					var $el = $orig
						.clone()
						.addClass("dropped")
						.css({"position": "static", "left": null, "right": null});
						
						
					// field type
					var fieldType= $orig.find("span").attr("id");
					 
					// id
					var id = makeKey(5);//$orig.find("div").attr("id");
					// Create New field on dropped
					initField(fieldType,id);
					
					// Render Canvas
					renderCanvas();
					// Render Form view
					renderForm();
					  
				 
					 
				} else {
					if($(this)[0]!=$orig.parent()[0]) {
						var $el = $orig
							.clone()
							.css({"position": "static", "left": null, "right": null})
							.appendTo(this);
						$orig.remove();
					}
				}
			}
		}).sortable();
		
	}
function SetformToLocalStore(formKey, hdnHasLayout) {

	_formKey = formKey;
	var frmObject = "";
	if (hdnHasLayout === "0") {
		// new json header
		localStorage[_formKey] = "";
		frmObject = {
			"ODataClientFilter": {
				"ProjectTitle": _frmProjectTitle,
				"FormTitle": _frmFormTitle,
				"HTMLSelector": "",
				"ODataClientRequest": {
					"DataURL": "api/v1/",
					"RequestMethod": "GET",
					"RequestContentType": "application/x-www-form-urlencoded",
					"ReturnDataType": "json"
				},
				"ClientFilterRows": [
					{
						"RowNo": 1,
						"ClientFilters": [
						]
					}
				]
			}
		};
 
		var frmData = JSON.stringify(frmObject);
		//alert("Local Sorage data"+ frmData);
		localStorage[_formKey] = frmData;
		return;
	}

	localStorage[_formKey] = JSON.stringify(JSON.parse(localStorage[_formKey].replace(/&quot;/g, '"')));
	renderCanvas();
}

	 
	$(document).on("click", ".edit-link", function(ev) {
	 
			var key = $(this).parent().parent().parent().attr("id");
            $(".header").removeClass("col-md-10");
            $(".header").addClass("col-md-6");
            $(".detailsView").css("display", "block");
			$(".field_key").text(key);	
			
			resetPropPanel();
			
			var frmState= getFormState();
			//console.log(getFieldByPropVal(frmState.ODataClientFilter.ClientFilterRows[0].ClientFilters,"Key",key));
			setFieldPropsByPropVal(getFieldByPropVal(frmState.ODataClientFilter.ClientFilterRows[0].ClientFilters,"Key",key));
			//alert(getFieldByPropVal(frmState.ODataClientFilter.ClientFilterRows[0].ClientFilters,"id",id).Name);
        });
		
 	 $(document).on("click", ".close", function(ev) {	
            $(".detailsView").css("display", "none");
            $(".header").removeClass("col-md-6");
            $(".header").addClass("col-md-10");
			$(".field_key").text("");
			resetPropPanel();
         });
		
	 
	$(document).on("click", ".remove-link", function(ev) {
		
		var key = $(this).parent().parent().parent().attr("id");
		removeField(key);
		$(this).parent().parent().parent().remove();
		
	});
	 
	function removeField(key){
 		var documentJson=getFormState();
        if (documentJson !== null && documentJson !== "" && documentJson !== undefined) {
			var items  = documentJson.ODataClientFilter.ClientFilterRows[0].ClientFilters; 
			var filtered = items.filter(function(item) { 
			   return item.Key !== key;  
			});
			var frmState= getFormState();
			frmState.ODataClientFilter.ClientFilterRows[0].ClientFilters="";
		    frmState.ODataClientFilter.ClientFilterRows[0].ClientFilters=filtered;
			//Set back form state
			setFormState(frmState)
			renderCanvas();
        }
	}

	
$(document).on("change", ".mb-3.row input[type='text']", function(ev) {
		var key=$(".field_key").text();
		var _frmState = getFormState();
		var field = getFieldByPropVal(_frmState.ODataClientFilter.ClientFilterRows[0].ClientFilters,"Key",key)
 		// Set new Value
		var _name = $(this).parent().parent().find('.data-name').attr("id");
        var _value = $(this).parent().parent().find('.data-value').val();
		 
		if(_name.startsWith("Is") || _name.startsWith("Visible") || _name.startsWith("HasDependantChild")){
			 var val = (_value === "true");
 			_value = val;
		}
		
		//Get tab to identify the object structure
		//alert($(this).parent().parent().parent().parent().parent().find('.active').attr("id"));
		var tab = ($(this).parent().parent().parent().parent().parent().find('.active').attr("id"));	
		
		if(tab == "tab0")
			field[_name] = _value;	
		else if(tab == "tab1") 
			field.ClientControl[_name] = _value;	
		else if(tab == "tab2") 
			field.ClientControl.ClientContorlSource[_name] = _value;	
		else if(tab == "tab3") 
			field.ClientControl.ClientContorlSource.ODataClientRequest[_name] = _value;	
		 
		alert(_name + ":" + _value);
 
		// Set back the form state
		setFormState(_frmState);
	    
		// Render Canvas
		renderCanvas();
		// Render Form view
		renderForm();

	});
	
   function resetPropPanel(){
	   $('#tab0 .mb-3 row').each(function () {
            $(this).find('.data-value').val("");
	    });
   }   
   
   function getFormState(){
	   return JSON.parse(localStorage[_formKey]);
   }	
   function setFormState(frmState){
       	var frmData = JSON.stringify(frmState);
	   localStorage[_formKey] = frmData;
   }
	
   function initField(fieldType,key){
   
		resetPropPanel();
		$(".field_key").text(key);
   
		var objFltr = {}
		var objCtrl = {}
		var objSrc = {}
		var objReq = {}
        // key id attribute forward to manage get/set attributes
		objFltr["Key"] = key;
		
	   $('#tab0 .mb-3 row').each(function () {
            var _name = $(this).find('.data-name').attr("id");
            var _value = $(this).find('.data-value').val();
			objFltr[_name] = _value;	
 		//console.log(JSON.stringify(objFltr));
	    });
		
	   $('#tab1 .mb-3 row').each(function () {
            var _name = $(this).find('.data-name').attr("id");
            var _value = $(this).find('.data-value').val();
			objCtrl[_name] = _value;
		});		
	   $('#tab2 .mb-3 row').each(function () {
            var _name = $(this).find('.data-name').attr("id");
            var _value = $(this).find('.data-value').val();
			objSrc[_name] = _value;
		});
	   $('#tab3 .mb-3 row').each(function () {
            var _name = $(this).find('.data-name').attr("id");
            var _value = $(this).find('.data-value').val();
			objReq[_name] = _value;
		});
		
		// Setting defaults
		objFltr["Name"] = fieldType;
		objFltr["Visible"] = true;
		objFltr["Caption"] = fieldType;
		objFltr["IsDependant"] = false;
		// Control
		objCtrl["ControlType"] = fieldType;
		objCtrl["ParentIdentifier"] = getFieldSelector(fieldType);
		objCtrl["HasDependantChild"] = false;
		
		// Src for dropdown
		if(fieldType == "DropDown")
		   objSrc["SourceType"] = "Static";

		
        // Add Ctrl
		objFltr["ClientControl"] = objCtrl;
	    // Add Src
		objCtrl["ClientContorlSource"] = objSrc;
		// Add Method like get/post request
	 	objSrc["ODataClientRequest"] = objReq;
		
		// get form data and add new field
 	    var frmState= getFormState();
		frmState.ODataClientFilter.ClientFilterRows[0].ClientFilters.push(objFltr);
		
		//Set back form state
		setFormState(frmState)
		 
	
   }

   function getFieldSelector(fieldType){
		var selector;
		if(fieldType=="TextBox")
			selector =".js_textBoxArea";
		if(fieldType=="DropDown")
			selector =".js_dropDownArea";
		if(fieldType=="Date")
			selector =".js_dateArea";
		if(fieldType=="CheckBox")
			selector =".js_chkBoxArea";
	 	
		return selector;
   }
   
   function getFieldByPropVal(fields, prop, val){
		for (var i = 0, length = fields.length; i < length; i++) {
			if (fields[i][prop] == val){
				return fields[i];
			}
		}
	}
   
   function setFieldPropsByPropVal(field){
	 		
	   $('#tab0 .mb-3 row').each(function () {
            var _name = $(this).find('.data-name').attr("id");
            $(this).find('.data-value').val(field[_name]);
	    });
	   $('#tab1 .mb-3 row').each(function () {
            var _name = $(this).find('.data-name').attr("id");
            $(this).find('.data-value').val(field.ClientControl[_name]);
	    });
	   $('#tab2 .mb-3 row').each(function () {
            var _name = $(this).find('.data-name').attr("id");
            $(this).find('.data-value').val(field.ClientControl.ClientContorlSource[_name]);
	    });
	   $('#tab3 .mb-3 row').each(function () {
            var _name = $(this).find('.data-name').attr("id");
            $(this).find('.data-value').val(field.ClientControl.ClientContorlSource.ODataClientRequest[_name]);
	    });
   }   
  
	// Make key for each field in shcema
	  function makeKey(length) {
		var key = '';
		var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
		var charactersLength = characters.length;
		for( var i = 0; i < length; i++ ) {
		  key += characters.charAt(Math.floor(Math.random() * charactersLength));
	   }
	   return key;
	}
   
   
function renderForm() {
     document.getElementById("viewer").innerHTML='<object type="text/html" class="col-md-12" data="/forms/form_viewer.html"  width="100%" height="400" style="overflow:hidden;width: 100%; height: 100%px" ></object>';
   }
   // Dowload Schema file
   function downloadSchema(content, fileName, contentType) {
    var a = document.createElement("a");
    var file = new Blob([content], {type: contentType});
    a.href = URL.createObjectURL(file);
    a.download = fileName;
    a.click();
  }
   // Open Schema file

   function openSchema(fileName) {
		$.getJSON(fileName, function(json) {
		 return json;
	});
   }
	 
  // Canvas Code
    function renderCanvas() { 
		var documentJson=getFormState();
		$("#canvas").empty();
        if (documentJson !== null && documentJson !== "" && documentJson !== undefined) {
            //Order By rows 
			
            $.each(documentJson.ODataClientFilter.ClientFilterRows, function (index, obj) {
                
				if (obj !== "" && obj !== null && obj !== "") {
                    $.each(obj.ClientFilters.filter(fil => fil.IsDependant === false), function (ind, filter) {
                       //alert(filter.ClientControl.ControlType);
					    switch (filter.ClientControl.ControlType) {
                            case "DropDown":
                                renderDropDown(filter, obj.ClientFilters);
                                break;
                            case "TextBox":
                                renderTextBox(filter, obj.ClientFilters);
                                break;
                            case "Date":
                                renderDate(filter, obj.ClientFilters);
                                break;
                             case "CheckBox":
                                renderCheckBox(filter, obj.ClientFilters);
                                break; 
                            default :
                        }
                    });
                }
            });
        }
    } 
function renderDropDown(filter, currentFilters) {
	var row = $(`<div  id=${filter.Key} class="row p-1"></div>`);
	var col = $(`<div class="col-md-5"></div>`);
	var label = `<label class="form-label" for="${filter.Name}">${filter.Name}</label>`;
	var combo = $(`<select disabled id="ddl_${filter.Name}" class="form-control js_remove_${filter.Name}"></select>`)
                .attr("data-eleType", "DropDown")
                .attr("filter", filter).attr("name", filter.Name);
        combo.append(`<option value="">-- Select ${filter.Name} --</option>`);
		col.append(label);
		col.append(combo);
		row.append(col).append(tools);
		$("#canvas").append(row);
	}
function renderTextBox(filter, currentFilters) {

	var row = $(`<div  id=${filter.Key} class="row p-1"></div>`);
	var col = $(`<div class="col-md-5"></div>`);
	var label = `<label class="form-label" for="${filter.Name}">${filter.Name}</label>`;
	var textBox = $(`<input disabled type="text" data-eleType="TextBox"s class="form-control js_remove_${filter.Name}" name="${filter.Name}" id="txt_${filter.Name}" filterJson='${JSON.stringify(filter)}' currentFilterList='${JSON.stringify(currentFilters)}'/>`);
	col.append(label);
	col.append(textBox);
	row.append(col).append(tools);
	$("#canvas").append(row);

  }

function renderDate(filter, currentFilters) {
 		var row = $(`<div  id=${filter.Key} class="row p-1"></div>`);
		var col = $(`<div class="col-md-5"></div>`);
		var label = `<label class="form-label" for="${filter.Name}">${filter.Name}</label>`;
 		var date = $(`<input disabled type="date" data-eleType="Date" class="form-control js_remove_${filter.Name}" name="${filter.Name}" id="txt_${filter.Name}" filterJson='${JSON.stringify(filter)}' currentFilterList='${JSON.stringify(currentFilters)}'/>`);
		col.append(label);
	    col.append(date);
		row.append(col).append(tools);
		$("#canvas").append(row)
}
  function renderCheckBox (filter, currentFilters) {
		var row = $(`<div  id=${filter.Key} class="row p-1"></div>`);
		var col = $(`<div class="col-md-5"></div>`);
		var label = `<label class="form-check-label" for="${filter.Name}">&nbsp;${filter.Name}</label>`;
		var checkbox = $(`<input disabled type="checkbox" data-eleType="CheckBox"s class="form-check-input js_remove_${filter.Name}" name="${filter.Name}" id="chk_${filter.Name}" filterJson='${JSON.stringify(filter)}' currentFilterList='${JSON.stringify(currentFilters)}'/>`);
		col.append(checkbox);
		col.append(label);
		row.append(col).append(tools);
		$("#canvas").append(row)
  }
   
	
   