
var _hostUrl = '';
var _utility = new Utility();
(function () {
    try {
       
        var _ajaxHelper = new AjaxHelper();
        var projectId = $('#hdnProjId').val(); 
        var modalDialog = document.getElementById('createNewWorkflow');
        _hostUrl = _utility.GetHostUrl();
        var redirectUrl = _hostUrl+"Project/" + projectId + "/Workflows";
        var popupTimeOut = 500;
        //#Workflow Create UI elements
        var WorkflowViewModel = {
            projectId: '#hdnProjId',
            WorkflowName: '#inputWorkflowName',
            WorkflowTitle: '#inputWorkflowTitle' 

        }
        //#Workflow Data from UI elements
        var getFormData = function () {
            var newWorkflowData = {};
            newWorkflowData.projectId = $(WorkflowViewModel.projectId).val();;
            newWorkflowData.name = $(WorkflowViewModel.WorkflowName).val();
            newWorkflowData.title = $(WorkflowViewModel.WorkflowTitle).val();
            return newWorkflowData;
        };


        //#Workflow Update UI elements
        var WorkflowUpdateViewModel = {
            projectId: '#hdnProjId',
            formKey: '#inputKey',
            title: '#inputTitle'

        }
        //#Workflow Data from UI elements
        var getFormUpdatedData = function () {
            var updatedFormData = {};
            updatedFormData.projectId = $(WorkflowUpdateViewModel.projectId).val();;
            updatedFormData.formKey = $(WorkflowUpdateViewModel.formKey).val();
            updatedFormData.title = $(WorkflowUpdateViewModel.title).val();
            return updatedFormData;
        };
  
        //#Workflow Remove UI elements
        var RemWorkflowViewModel = {
            projectId: '#hdnProjId',
            id: '#inputWorkflowId' 

        }
        //#Workflow Data from UI elements
        var getRemWorkflowData = function () {
            var remWorkflowData = {};
            remWorkflowData.projectId = $(RemWorkflowViewModel.projectId).val();
            remWorkflowData.WorkflowId = $(RemWorkflowViewModel.id).val();
            return remWorkflowData;
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
                            if (event.target.id === 'workflow-create') {
                                CreateWorkflow();
                                event.preventDefault()
                            }
                            if (event.target.id === 'workflow-update') {
                                UpdateWorkflow();
                                event.preventDefault()
                            }
                            if (event.target.id === 'workflow-remove') {
                                RemoveWorkflow();
                                event.preventDefault()
                            }

                        }
                        form.classList.add('was-validated')
                    }, false)
                })

             
        })()

        // Create New Workflow        
        var CreateWorkflow = async function () {
            _utility.toggleSpinner(true);
            var postData = getFormData();
            try {
                var response = await _ajaxHelper.postDataAsync(_hostUrl + "api/Workflows/create", postData);
                if (response.success) {
                    //alert('Workflow created successfully');
                    _utility.toggleSpiner(false);
                    modalDialog.hide();
                    _utility.showAlert("success", "Workflow created successfully", redirectUrl, popupTimeOut);

                }
                else {
                    //alert('Error in creating Workflow');
                    _utility.toggleSpiner(false);
                    _utility.showAlert("error", 'Error in creating Workflow ' + response.ErrorMessage, redirectUrl, popupTimeOut);
                }
            }
            catch (error) {
                _utility.toggleSpinner(false);
                _utility.showAlert("error", response.ErrorMessage, redirectUrl, popupTimeOut);
            }
        }

        // Update Workflow
        var UpdateWorkflow = async function () {
             _utility.toggleSpinner(true);
            var postData = getWorkflowUpdatedData();
            try {
                var response = await _ajaxHelper.postDataAsync(_hostUrl + "api/Workflows/update", postData);
                if (response.success) {
                    //alert('Workflow updated successfully');
                    _utility.toggleSpinner(false);
                    _utility.showAlert("success", "Workflow updated successfully", redirectUrl, popupTimeOut);
                }
                else {
                    //alert('Error in updating Workflow');
                    _utility.toggleSpinner(false);
                    _utility.showAlert("error", response.ErrorMessage, redirectUrl, popupTimeOut);
                }
            }
            catch (error) {
                _utility.toggleSpinner(false);
                _utility.showAlert("error", response.ErrorMessage, redirectUrl, popupTimeOut);
            }
        }

        // Remove Workflow        
        var RemoveWorkflow = async function () {
            _utility.toggleSpinner(true);
            var postData = getRemWorkflowData();
            try {
                var response = await _ajaxHelper.postDataAsync(_hostUrl + "api/Workflows/remove", postData);
                if (response.success) {
                    //alert('Workflow removed successfully');
                    _utility.toggleSpinner(false);
                    _utility.showAlert("success", "Workflow removed successfully", redirectUrl, popupTimeOut);
                }
                else {
                    //alert('Error in creating Workflow');
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
