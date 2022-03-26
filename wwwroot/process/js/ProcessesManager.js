
var _hostUrl = '';
(function () {

    try {
        var _ajaxHelper = new AjaxHelper();
        var _utility = new Utility();
        var projectId = $('#hdnProjId').val(); 
        var modalDialog = document.getElementById('createNewProcess');
        _hostUrl = _utility.GetHostUrl();
        var redirectUrl = _hostUrl+"Project/" + projectId + "/processes";
        var popupTimeOut = 500;

        //#Process Create UI elements
        var ProcessViewModel = {
            projectId: '#hdnProjId',
            processName: '#inputProcessName',
            processTitle: '#inputProcessTitle' 

        }
        //#Process Data from UI elements
        var getFormData = function () {
            var newProcessData = {};
            newProcessData.projectId = $(ProcessViewModel.projectId).val();;
            newProcessData.name = $(ProcessViewModel.processName).val();
            newProcessData.title = $(ProcessViewModel.processTitle).val();
            return newProcessData;
        };


        //#Process Update UI elements
        var ProcessUpdateViewModel = {
            projectId: '#hdnProjId',
            formKey: '#inputKey',
            title: '#inputTitle'

        }
        //#Process Data from UI elements
        var getFormUpdatedData = function () {
            var updatedFormData = {};
            updatedFormData.projectId = $(ProcessUpdateViewModel.projectId).val();;
            updatedFormData.formKey = $(ProcessUpdateViewModel.formKey).val();
            updatedFormData.title = $(ProcessUpdateViewModel.title).val();
            return updatedFormData;
        };


        //#Process Remove UI elements
        var RemProcessViewModel = {
            projectId: '#hdnProjId',
            id: '#inputProcessId' 

        }
        //#Process Data from UI elements
        var getRemProcessData = function () {
            var remProcessData = {};
            remProcessData.projectId = $(RemProcessViewModel.projectId).val();
            remProcessData.processId = $(RemProcessViewModel.id).val();
            return remProcessData;
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
                            if (event.target.id === 'process-create') {
                                CreateProcess();
                                event.preventDefault()
                            }
                            if (event.target.id === 'process-update') {
                                UpdateProcess();
                                event.preventDefault()
                            }
                            if (event.target.id === 'process-remove') {
                                RemoveProcess();
                                event.preventDefault()
                            }

                        }
                        form.classList.add('was-validated')
                    }, false)
                })

             
        })()

        // Create New Process        
        var CreateProcess = async function () {
            _utility.toggleSpinner(true);
            var postData = getFormData();
            try {
                var response = await _ajaxHelper.postDataAsync(_hostUrl + "api/Processes/create", postData);
                if (response.success) {
                    //alert('Process created successfully');
                    _utility.toggleSpiner(false);
                    modalDialog.hide();
                    _utility.showAlert("success", "Process created successfully", redirectUrl, popupTimeOut);

                }
                else {
                    //alert('Error in creating process');
                    _utility.toggleSpiner(false);
                    _utility.showAlert("error", 'Error in creating process ' + response.ErrorMessage, redirectUrl, popupTimeOut);
                }
            }
            catch (error) {
                _utility.toggleSpinner(false);
                _utility.showAlert("error", response.ErrorMessage, redirectUrl, popupTimeOut);
            }
        }

        // Update process
        var UpdateProcess = async function () {
             _utility.toggleSpinner(true);
            var postData = getProcessUpdatedData();
            try {
                var response = await _ajaxHelper.postDataAsync(_hostUrl + "api/Processes/update", postData);
                if (response.success) {
                    //alert('Process updated successfully');
                    _utility.toggleSpinner(false);
                    _utility.showAlert("success", "Process updated successfully", redirectUrl, popupTimeOut);
                }
                else {
                    //alert('Error in updating process');
                    _utility.toggleSpinner(false);
                    _utility.showAlert("error", response.ErrorMessage, redirectUrl, popupTimeOut);
                }
            }
            catch (error) {
                _utility.toggleSpinner(false);
                _utility.showAlert("error", response.ErrorMessage, redirectUrl, popupTimeOut);
            }
        }

        // Remove Process        
        var RemoveProcess = async function () {
            _utility.toggleSpinner(true);
            var postData = getRemProcessData();
            try {
                var response = await _ajaxHelper.postDataAsync(_hostUrl + "api/Processes/remove", postData);
                if (response.success) {
                    //alert('Process removed successfully');
                    _utility.toggleSpinner(false);
                    _utility.showAlert("success", "Process removed successfully", redirectUrl, popupTimeOut);
                }
                else {
                    //alert('Error in creating Process');
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
        _utility.toggleSpiner(false);
    }


})();
