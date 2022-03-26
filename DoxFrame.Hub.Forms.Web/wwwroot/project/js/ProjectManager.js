
var _hostUrl = '';
 (function (){
  
    try {
        var _ajaxHelper = new AjaxHelper();
        var _utility = new Utility();
        _hostUrl = _utility.GetHostUrl();
        var redirectUrl = _hostUrl; 
        var popupTimeOut = 500;

       
        //#Project Create UI elements
        var ProjectViewModel = {
            hubUserId: '#hdnHubUserId',
            projectName: '#inputProjectTitle',
            projectSummary: '#inputProjectSummary'

        }
        //#HubUser Data from UI elements
        var getFormData = function () {
            var newProjectData = {};
            newProjectData.hubUserId = $(ProjectViewModel.hubUserId).val();
            newProjectData.projectName = $(ProjectViewModel.projectName).val();
            newProjectData.summary = $(ProjectViewModel.projectSummary).val();
            return newProjectData;
        };


        //#Project Remove UI elements
        var RemProjectViewModel = {
            tenantId: '#hdnTenantId',
            projectId: '#inputProjectId'

        }
        //#Project Data from UI elements
        var getRemProjectData = function () {
            var remProjectData = {};
            remProjectData.tenantId = $(RemProjectViewModel.tenantId).val();
            remProjectData.projectId = $(RemProjectViewModel.projectId).val();
            return remProjectData;
        };
 
        // Submit form validation : JavaScript for disabling form submissions if there are invalid fields
        (function () {
            'use strict'
            // Fetch all the forms we want to apply custom Bootstrap validation styles to
            var forms = document.querySelectorAll('.needs-validation')
            // Loop over them and prevent submission
            Array.prototype.slice.call(forms)
                .forEach(function (form) {
                    form.addEventListener('submit', function (event) {
                        if (!form.checkValidity()) {
                            event.preventDefault()
                            event.stopPropagation()
                        }
                        else {
                            if (event.target.id === 'project-create') {
                                CreateProject();
                                event.preventDefault()
                            }
                            if (event.target.id === 'proj-remove') {
                                RemoveProject();
                                event.preventDefault()
                            }
                        }
                        form.classList.add('was-validated')
                    }, false)
                })
        })()

    // Create New Project        
        var CreateProject = async function () {
            _utility.toggleSpinner(true);
            var postData = getFormData();
            //alert(JSON.stringify(postData));
            try {
                var response = await _ajaxHelper.postDataAsync(_hostUrl + "api/Tenants/project/create", postData);
            if (response.success) {
                    //alert('Tenant created successfully');
                    _utility.toggleSpinner(false);
                     _utility.showAlert("success", "Project created successfully", redirectUrl, popupTimeOut);
            }
            else {
                //alert("Exception Error :" + response.result);
                    _utility.toggleSpinner(false);
                    _utility.showAlert("error", "Error in creating Project", null, popupTimeOut);
                }
            }
            catch (error) {
            _utility.toggleSpinner(false);
            _utility.showAlert("error", error, null, popupTimeOut);
            }
        }

        // Remove Project        
        var RemoveProject = async function () {
            _utility.toggleSpinner(true);
            var postData = getRemProjectData();
            try {
                var response = await _ajaxHelper.postDataAsync(_hostUrl + "api/Tenants/project/remove", postData);
                if (response.success) {
                    _utility.toggleSpinner(false);
                    _utility.showAlert("success", "Project removed successfully", redirectUrl, popupTimeOut);
                }
                else {
                    //alert('Error in creating Form');
                    _utility.toggleSpinner(false);
                    _utility.showAlert("error", response.ErrorMessage, redirectUrl, popupTimeOut);
                }
            }
            catch (error) {
                _utility.toggleSpinner(false);
                _utility.showAlert("error", response.ErrorMessage, redirectUrl, popupTimeOut);
            }
        }
    

    }
    catch (error) {
        if (error !== undefined) 
            _utility.showAlert("error", error, null, popupTimeOut);
            _utility.toggleSpinner(false);
    }
 

})();
 