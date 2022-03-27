
import * as StandardData from '../js/StandardData.js';

var documentName = "";
var areaName = "";
var documentJson = {};
var generatedFilters = [];
var userCompanyId = 0;
var reqObj = {};
var FormControls = {
    hdnAreaName: "#hdnAreaName",
    hdnDocumentName: "#hdnDocumentName",
    hdnDocumentJson: "#hdnDocumentJson",
    ParentDiv: ".js_filterDiv",
    DynamicControl: ".js_DynamicElement",
    btnShowData: "#btnFilterData",
    btnClearFilter: "#btnClearFitlers"

};
//var _ajaxHelper = new AjaxHelper();
var FilterComponent = {
    Init: function () {
        userCompanyId = 'SampleProject'; //JSON.parse(localStorage.getItem("user_company")).company;
        areaName = $(FormControls.hdnAreaName).val();
        documentName = $(FormControls.hdnDocumentName).val();
        if ($(FormControls.hdnDocumentJson).val() !== null && $(FormControls.hdnDocumentJson).val() !== "" && $(FormControls.hdnDocumentJson).val() !== undefined) {
            //#replacing companyId if exists in json string
            var jsonString = $(FormControls.hdnDocumentJson).val();
            jsonString = jsonString.replace(/#CompanyId#/g, `${userCompanyId}`);
            //#replacing companyId if exists in json string

            documentJson = JSON.parse(jsonString);
            this.LoadFilters();
        }
        
    },
    LoadFilters: function () {
        if (documentJson !== null && documentJson !== "" && documentJson !== undefined) {
            //Order By rows 

            $.each(documentJson.ODataClientFilter.ClientFilterRows, function (index, obj) {
                if (obj !== "" && obj !== null && obj !== "") {
                    $.each(obj.ClientFilters.filter(fil => fil.IsDependant === false), function (ind, filter) {
                        switch (filter.ClientControl.ControlType) {
                            case "DropDown":
                                FilterComponent.BindDropDown(filter, obj.ClientFilters);
                                break;
                            case "TextBox":
                                FilterComponent.BindTextBox(filter, obj.ClientFilters);
                                break;
                            case "Date":
                                FilterComponent.BindDate(filter, obj.ClientFilters);
                                break;
                            case "CheckBox":
                                FilterComponent.BindCheckBox(filter, obj.ClientFilters);
                                break;
                            default:
                            //console.log("Nothing to Bind");
                        }
                    });
                }
            });
        }
    },
    GetDocumentJson: function () {
        try {
            //ajax call to get the Document json
            $.ajax({
                'async': true,
                url: `Filter/FilterComponent/GetDocumentJson`,
                contentType: 'application/json; charset=utf-8',
                type: 'get',
                dataType: "json",
                data: { areaName: areaName, documentName: documentName },
                success: function (response) {
                    alert(response);
                },
                error: function (response) {
                    console.log(response);
                }
            });
        } catch (e) {
            console.log(e);
        }
    },
    BindDropDown: function (filter, currentFilters) {
 		//var hostURL = "http://localhost:8003/";//_ajaxHelper.GetApiUrl(filter.AreaName);
        //#region Binding main DropDown


        var row = $(`<div  id=${filter.Key} class="row p-1"></div>`);
        var col = $(`<div class="col-md-5"></div>`);
        var label = `<label class="form-label" for="${filter.Name}">${filter.Name}</label>`;
        var combo = $(`<select disabled id="ddl_${filter.Name}" class="form-control js_remove_${filter.Name}"></select>`)
            .attr("data-eleType", "DropDown")
            .attr("filter", filter).attr("name", filter.Name);
        //combo.append(`<option value="">-- Select ${filter.Name} --</option>`);
        col.append(label);
  

        // In case property api        
        if (filter.ClientControl.ClientContorlSource.SourceType === "Api") {
            $.ajax({
                'async': false,
                url: `${filter.ClientControl.ClientContorlSource.ODataClientRequest.ODataURL}`,
                contentType: 'application/json; charset=utf-8',
                type: 'get',
                dataType: "json",
                success: function (response) {
                    if (response !== null && response !== undefined && response !== "") {
                        var dropDownList = response;// response.value; // response.records;
                        combo = $(`<select id="ddl_${filter.Name}" class="form-control js_DynamicElement js_remove_${filter.Name}"></select>`)
                            .attr("data-eleType", "DropDown")
                            .attr("filter", filter).attr("name", filter.Name)
                            .attr("filterJson", JSON.stringify(filter))
                            .attr("currentFilterList", JSON.stringify(currentFilters));
                        combo.append(`<option value="0">-- All --</option>`);
						//(this is child for a parent) wait for cascade parent event with filter id to load values
						if(filter.ClientControl.FilterField === ""){
							$.each(dropDownList, function (i, el) {
								combo.append(`<option value="${el[filter.ClientControl.SourceField]}">${el[filter.ClientControl.DisplayField]}</option>`);
							});
						}
                        col.append(combo);
                    }
                },
                error: function (response) {
                    console.log(response);
                }
            });
		}
		else if(filter.ClientControl.ClientContorlSource.SourceType === "Static"){

				//Get the fixed date values data from json 
            var listText = '';
            var listValues = '';
		    // validate the data values in fields

             
            if (filter.ClientControl.ClientContorlSource.FixedFields.length > 0 || filter.ClientControl.ClientContorlSource.FixedValues > 0) {
                listText = this.GetAraryFromString(filter.ClientControl.ClientContorlSource.FixedFields);
                listValues = this.GetAraryFromString(filter.ClientControl.ClientContorlSource.FixedValues);
            }


				 combo = $(`<select id="ddl_${filter.Name}" class="form-control js_DynamicElement js_remove_${filter.Name}"></select>`)
                .attr("data-eleType", "DropDown")
                .attr("filter", filter).attr("name", filter.Name)
                .attr("filterJson", JSON.stringify(filter))
                .attr("currentFilterList", JSON.stringify(currentFilters));
				combo.append(`<option value="">-- All --</option>`);
				for (var i = 0; i < listText.length; i++) {
				   combo.append(`<option value="${listValues[i]}">${listText[i]}</option>`);
				}
				col.append(combo);
		
         } else if (filter.ClientControl.ClientContorlSource.SourceType === "File") {
            //Get the static data from StandardData

            var dropdownList = StandardData[filter.ClientControl.ClientContorlSource.StaticObjectName];

            combo = $(`<select id="ddl_${filter.Name}" class="form-control js_DynamicElement js_remove_${filter.Name}"></select>`)
                .attr("data-eleType", "DropDown")
                .attr("filter", filter).attr("name", filter.Name)
                .attr("filterJson", JSON.stringify(filter))
                .attr("currentFilterList", JSON.stringify(currentFilters));
            combo.append(`<option value="">-- All --</option>`);
            $.each(dropdownList, function (i, el) {
                combo.append(`<option value="${el.name}">${el.displayname}</option>`);
            });
            col.append(combo);
        }  
        row.append(col);
        $(filter.ClientControl.ParentIdentifier).append(row);
    },
	BindCascadeDropDown: function (filter, currentFilters) {
		// on select cascade affect call back
        // This function load only values into existing control rather adding new control 
		//alert(filter.ClientControl.ClientContorlSource.ODataClientRequest.ODataURL);
		// get affect control id
		var combo = $(`#ddl_${filter.Name}`)
		combo.empty(); 
		var dropDownList = "";    
        if (filter.ClientControl.ClientContorlSource.SourceType === "Api") {
            alert(filter.ClientControl.ClientContorlSource.ODataClientRequest.ODataURL);
            $.ajax({
                'async': false,
                url: `${filter.ClientControl.ClientContorlSource.ODataClientRequest.ODataURL}`,
                contentType: 'application/json; charset=utf-8',
                type: 'get',
                dataType: "json",
                success: function (response) {
                    if (response !== null && response !== undefined && response !== "") {
                        dropDownList = response.records;//response.value;
						
							combo.append(`<option value="">-- All --</option>`);
							$.each(dropDownList, function (i, el) {
								combo.append(`<option value="${el[filter.ClientControl.SourceField]}">${el[filter.ClientControl.DisplayField]}</option>`);
							});
                    }
                },
                error: function (response) {
                    console.log(response);
                }
            });
		}

    },
    BindTextBox: function (filter, currentFilters) {
        var row = $(`<div  id=${filter.Key} class="row p-1"></div>`);
        var col = $(`<div class="col-md-5"></div>`);
        var label = `<label class="form-label" for="${filter.Name}">${filter.Name}</label>`;
         if (filter !== undefined && filter !== null && filter !== "") {
             var textBox = $(`<input type="text" data-eleType="TextBox"s class="form-control js_remove_${filter.Name}" name="${filter.Name}" id="txt_${filter.Name}" filterJson='${JSON.stringify(filter)}' currentFilterList='${JSON.stringify(currentFilters)}'/>`);
             col.append(label);
             col.append(textBox);
             row.append(col)
             $(filter.ClientControl.ParentIdentifier).append(row);
        }
    },
    BindDate: function (filter, currentFilters) {


        var row = $(`<div  id=${filter.Key} class="row p-1"></div>`);
        var col = $(`<div class="col-md-5"></div>`);
        var label = `<label class="form-label" for="${filter.Name}">${filter.Name}</label>`;
        var date = $(`<input disabled type="date" data-eleType="Date" class="form-control js_remove_${filter.Name}" name="${filter.Name}" id="txt_${filter.Name}" filterJson='${JSON.stringify(filter)}' currentFilterList='${JSON.stringify(currentFilters)}'/>`);
        if (filter !== undefined && filter !== null && filter !== "") {
			/* date = $(`<div id="divDate_${filter.Key}" class="input-group field-with-icon date"><input type="date" id="txtDate_${filter.Key}" data-eleType="Date" class="form-control js_DynamicElement js_remove_${filter.Name}" name="${filter.Name}"  filterJson='${JSON.stringify(filter)}' currentFilterList='${JSON.stringify(currentFilters)}' /><a href="#" class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></a></div>
			<script type="text/javascript">
					$(function () {
					   $(divDate_${filter.Key}).datetimepicker({
								showClose: true, //close the picker
								format: "DD/MM/YYYY",
								calendarWeeks: true,
								sideBySide: true,
								minDate: new Date('01/01/2019'),//moment("01/01/2019"),
								maxDate: new Date('01/01/2040'),//moment("01/12/2040")                
						}).on('dp.change', function (e) {
							   if (e.oldDate !== e.date) {
									alert('You picked: ' + new Date(e.date).toLocaleDateString('en-US'))
								}
						});
					});
			</script>`); */
			
	    date = $(`<input type="date" id="txtDate_${filter.Key}" data-eleType="Date" class="form-control js_DynamicElement js_remove_${filter.Name}" name="${filter.Name}" placeholder="dd-mm-yyyy" value=""
        min="1997-01-01" max="2030-12-31" filterJson='${JSON.stringify(filter)}' currentFilterList='${JSON.stringify(currentFilters)}' />`);

         col.append(label);
         col.append(date);
         row.append(col) 
         $(filter.ClientControl.ParentIdentifier).append(row);
        }
    },
    BindCheckBox: function (filter, currentFilters) {

        var row = $(`<div  id=${filter.Key} class="row p-1"></div>`);
        var col = $(`<div class="col-md-5"></div>`);
  
 		if (filter !== undefined && filter !== null && filter !== "") {
	            var label = `<label class="form-check-label" for="${filter.Name}">&nbsp;${filter.Name}</label>`;
                var checkbox = $(`<input  type="checkbox" data-eleType="CheckBox"s class="form-check-input js_remove_${filter.Name}" name="${filter.Name}" id="chk_${filter.Name}" filterJson='${JSON.stringify(filter)}' currentFilterList='${JSON.stringify(currentFilters)}'/>`);
                col.append(checkbox);
                col.append(label);
                row.append(col);
                $(filter.ClientControl.ParentIdentifier).append(row);

		}
    },
    ChangeEvent: function (props) {
 		switch (props.currentFilterJson.ClientControl.ControlType) {
            case "DropDown":
				{
                    if (props.Value !== "0" && props.Value !== undefined && props.Value !== null) {
                        if (props.currentFilterJson.ClientControl.ClientContorlSource.SourceType === "Api" || props.currentFilterJson.ClientControl.ClientContorlSource.SourceType === "Static")
                            props.Value = parseInt(props.Value);
                        FilterComponent.CreateFilterArray(props);
                    } else {
                        FilterComponent.RemoveFilterFromArray(generatedFilters, props.currentFilterJson.Name);
						
                    }
                    if (props.currentFilterJson.ClientControl.HasDependantChild) {
                        var dependantFilter = props.currentFilterList.filter(x => x.Name === props.currentFilterJson.ClientControl.AffectFields)[0];
						
						//set load data from source
						dependantFilter.ClientControl.ParentValue = props.Value;
                        dependantFilter.ClientControl.ClientContorlSource.ODataClientRequest.ODataURL = `${dependantFilter.ClientControl.ClientContorlSource.ODataClientRequest.ODataURL}?filter=${dependantFilter.ClientControl.FilterField},eq,${dependantFilter.ClientControl.ParentValue}`;
                        if (props.Value !== "") {
                            FilterComponent.BindCascadeDropDown(dependantFilter, props.currentFilterList);
                        }
                    }

                }
                break;
            case "TextBox":
                {
                    if (props.Value !== "" && props.Value !== undefined && props.Value !== null) {
                        FilterComponent.CreateFilterArray(props);
                    } else {
                        FilterComponent.RemoveFilterFromArray(generatedFilters, props.currentFilterJson.Name);
                    }
                }
                break;
            case "Date":
				{
                    if (props.Value !== "" && props.Value !== undefined && props.Value !== null) {
                        FilterComponent.CreateFilterArray(props);
                    } else {
                        FilterComponent.RemoveFilterFromArray(generatedFilters, props.currentFilterJson.Name);
                    }
                }
                break;
            case "CheckBox":
                {
                    if (props.Value !== "" && props.Value !== undefined && props.Value !== null) {
                         FilterComponent.CreateFilterArray(props);
                    } else {
                        FilterComponent.RemoveFilterFromArray(generatedFilters, props.currentFilterJson.Name);
                    }
                }
                break;
            default:
                {
                    FilterComponent.CreateFilterArray(props);
                }
                break;
        }
    },
    FindAndRemoveElement: function (eleClassName) {
        var element = document.getElementById(`${eleClassName}`);
        console.log(element);
        if (element !== null && element !== undefined && element !== "") {
            element.remove();
        }
    },
    CreateFilterArray: function (props) {
		 
        var currentFilter = props.currentFilterJson;
        var currentFilterIndex = generatedFilters.findIndex(x => x.FilterName === currentFilter.Name);
        if (currentFilterIndex !== -1) {
            delete generatedFilters[currentFilterIndex];
            generatedFilters = generatedFilters.filter(function (el) {
                return el !== null;
            });
        }
        var newFilter = {
            field: currentFilter.ClientControl.FilterField,
            operator: currentFilter.ClientControl.FilterOperator,
            value: props.Value,
            FilterName: currentFilter.Name
        };
        generatedFilters.push(newFilter);
		 
		 
    },
    RemoveFilterFromArray: function (arr, value) {
        //var i = arr.length;
        //var currentFilterIndex = arr.findIndex(x => x.FilterName === value);
        //if (currentFilterIndex !== -1) {
        //    arr.splice(currentFilterIndex, 1);
        //}


        //- get all the filters assigned to Grid
        //- remove current filter if the filter value is 0 from filters
        //- empty the generated filters 
        //- then push all the filters from grid to generated filters
        var grid = $(`#${documentName}Grid`).data("kendoGrid");
        var existingfilters = grid.dataSource.filter().filters;

        var spliceIndex = existingfilters.findIndex(x => x.FilterName === value);
        if (spliceIndex !== -1)
            existingfilters.splice(spliceIndex, 1);

        generatedFilters = [];
        generatedFilters.push(...existingfilters);
    },
    GetAraryFromString: function (strValues) {
         return strValues.split(",");
	}
};


 
(function () {

    try {
        FilterComponent.Init();
		$(document).on("change", FormControls.DynamicControl, function () {
             var filterProperties = {
                Value: $(this).val(),
                Id: $(this).attr("id"),
                currentFilterJson: JSON.parse($(this).attr("filterJson")),
                currentFilterList: JSON.parse($(this).attr("currentFilterList")),
            };
            if ($(this).attr("data-eleType") === "CheckBox") {
                filterProperties.Value = $(`#${filterProperties.Id}`).is(":checked");
            }
            FilterComponent.ChangeEvent(filterProperties);
        });
		
	 
        //Show data Event
        /* $(document).on("click", FormControls.btnShowData, function () {
			alert('click');
            var grid = $(`#${documentName}Grid`).data("kendoGrid");
            var existingfilters = grid.dataSource.filter().filters;
            if (generatedFilters.length > 0) {
                $.each(generatedFilters, function (ind, value) {
                    var spliceIndex = existingfilters.findIndex(x => x.field === value.field);
                    if (spliceIndex !== -1)
                        existingfilters.splice(spliceIndex, 1);
                });
            }
            existingfilters.push(...generatedFilters);
            $(`#${documentName}Grid`).data("kendoGrid").dataSource.filter({
                filters: existingfilters
            });
            console.log(generatedFilters);
        }); */
		
		//Show data Event
        $(document).on("click", FormControls.btnShowData, function () {
			 
            //var grid = $(`#${documentName}Grid`).data("kendoGrid");
            //var existingfilters = grid.dataSource.filter().filters;
            if (generatedFilters.length > 0) {
                $.each(generatedFilters, function (ind, value) {
                    //var spliceIndex = existingfilters.findIndex(x => x.field === value.field);
                    //if (spliceIndex !== -1)
                        //existingfilters.splice(spliceIndex, 1);
					//alert(ind + ":" + value);
					//alert(JSON.stringify(value));
					//alert(value.FilterName+":"+value.value);
					reqObj[value.FilterName]=value.value;
					document.getElementById("reqbody").innerHTML = JSON.stringify(reqObj);
                });
            }
            //existingfilters.push(...generatedFilters);
            //$(`#${documentName}Grid`).data("kendoGrid").dataSource.filter({
            //    filters: existingfilters
            //});
            //console.log(generatedFilters);
        });
		
        //#region Clear filters event
        $(document).on("click", FormControls.btnClearFilter, function () {
            //var grid = $(`#${documentName}Grid`).data("kendoGrid");
            //var existingfilters = grid.dataSource.filter().filters;
            if (generatedFilters.length > 0) {
                $.each(generatedFilters, function (ind, value) {
                    //var spliceIndex = existingfilters.findIndex(x => x.field === value.field);
                    if (spliceIndex !== -1)
                        existingfilters.splice(spliceIndex, 1);
                });
            }
            //grid.dataSource.filter({
            //    filters: existingfilters
            //});
            generatedFilters = [];
            $(".js_dropDownArea select").val("");
            $(".js_textBoxArea input[type='text']").val("");
            $(".js_textBoxArea input[type='checkbox']").checked = false;
        });
        //#endregion
    } catch (error) {
        console.log();
    } finally {
        console.log("error");
    }
})();
