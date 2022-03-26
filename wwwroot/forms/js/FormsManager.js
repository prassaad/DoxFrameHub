
var _hostUrl = '';
(function () {

    try {
        var _ajaxHelper = new AjaxHelper();
        var _utility = new Utility();
        var projectId = $('#hdnProjId').val(); 
        var modalDialog = document.getElementById('createNewForm');
        _hostUrl = _utility.GetHostUrl();
        var redirectUrl = _hostUrl+"Project/" + projectId + "/forms";
        var popupTimeOut = 500;


        //#Form Create UI elements
        var FormViewModel = {
            projectId: '#hdnProjId',
            formTitle: '#inputFormTitle',
            operationType: "#selectFrmOpType"
            //errorSummary: "#errorSummary",

        }
        //#Form Data from UI elements
        var getFormData = function () {
            var newFormData = {};
            newFormData.projectId = $(FormViewModel.projectId).val();;
            newFormData.title = $(FormViewModel.formTitle).val();
            newFormData.operationType = $(FormViewModel.operationType).val();
            return newFormData;
        };


        //#Form Update UI elements
        var FormUpdateViewModel = {
            projectId: '#hdnProjId',
            formKey: '#inputKey',
            formDesc: "#inputDesc",
            operationType: "#selectFrmOpType",
            formMethod: '#selectFrmMethod',
            formEndpoint: '#selectFrmEndpoint',
            formId: '#hdnFormId',
            title: '#inputTitle'
            //errorSummary: "#errorSummary",

        }
        //#Form Data from UI elements
        var getFormUpdatedData = function () {
            var updatedFormData = {};
            updatedFormData.projectId = $(FormUpdateViewModel.projectId).val();;
            updatedFormData.formKey = $(FormUpdateViewModel.formKey).val();
            updatedFormData.description = $(FormUpdateViewModel.formDesc).val();;
            updatedFormData.operationType = $(FormUpdateViewModel.operationType).val();
            updatedFormData.requestMethod = $(FormUpdateViewModel.formMethod).val();
            updatedFormData.requestUri = $(FormUpdateViewModel.formEndpoint).val();
            updatedFormData.id = $(FormUpdateViewModel.formId).val();
            updatedFormData.title = $(FormUpdateViewModel.title).val();

            return updatedFormData;
        };


        //#Form Remove UI elements
        var RemFormViewModel = {
            projectId: '#hdnProjId',
            id: '#inputFormId'
            //errorSummary: "#errorSummary",

        }
        //#Form Data from UI elements
        var getRemFormData = function () {
            var remFormData = {};
            remFormData.projectId = $(RemFormViewModel.projectId).val();
            remFormData.formId = $(RemFormViewModel.id).val();
            return remFormData;
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
                            if (event.target.id === 'frm-create') {
                                CreateForm();
                                event.preventDefault()
                            }
                            if (event.target.id === 'frm-update') {
                                UpdateForm();
                                event.preventDefault()
                            }
                            if (event.target.id === 'frm-remove') {
                                RemoveForm();
                                event.preventDefault()
                            }

                        }
                        form.classList.add('was-validated')
                    }, false)
                })

            //await CreateForm();
        })()

        // Create New Form        
        var CreateForm = async function () {
            _utility.toggleSpinner(true);
            var postData = getFormData();
            try {
                var response = await _ajaxHelper.postDataAsync(_hostUrl + "api/Forms/create", postData);
                if (response.success) {
                    //alert('Form created successfully');
                    _utility.toggleSpiner(false);
                    modalDialog.hide();
                    _utility.showAlert("success", "Form created successfully", redirectUrl, popupTimeOut);

                }
                else {
                    //alert('Error in creating form');
                    _utility.toggleSpiner(false);
                    _utility.showAlert("error", 'Error in creating form ' + response.ErrorMessage, redirectUrl, popupTimeOut);
                }
            }
            catch (error) {
                _utility.toggleSpinner(false);
                _utility.showAlert("error", response.ErrorMessage, redirectUrl, popupTimeOut);
            }
        }

        // Update form
        var UpdateForm = async function () {
             _utility.toggleSpinner(true);
            var postData = getFormUpdatedData();
            try {
                var response = await _ajaxHelper.postDataAsync(_hostUrl + "api/Forms/update", postData);
                if (response.success) {
                    //alert('Form updated successfully');
                    _utility.toggleSpinner(false);
                    _utility.showAlert("success", "Form updated successfully", redirectUrl, popupTimeOut);
                }
                else {
                    //alert('Error in updating form');
                    _utility.toggleSpinner(false);
                    _utility.showAlert("error", response.ErrorMessage, redirectUrl, popupTimeOut);
                }
            }
            catch (error) {
                _utility.toggleSpinner(false);
                _utility.showAlert("error", response.ErrorMessage, redirectUrl, popupTimeOut);
            }
        }

        // Remove Form        
        var RemoveForm = async function () {
            _utility.toggleSpinner(true);
            var postData = getRemFormData();
            try {
                var response = await _ajaxHelper.postDataAsync(_hostUrl + "api/Forms/remove", postData);
                if (response.success) {
                    //alert('Form removed successfully');
                    _utility.toggleSpinner(false);
                    _utility.showAlert("success", "Form removed successfully", redirectUrl, popupTimeOut);
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
        _utility.toggleSpiner(false);
    }


})();
