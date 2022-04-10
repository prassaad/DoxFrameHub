
var _hostUrl = '';
 (function (){
  
    try {
        var _ajaxHelper = new AjaxHelper();
        var _utility = new Utility();
        _hostUrl = _utility.GetHostUrl();
        var redirectUrl = _hostUrl; 
        var popupTimeOut = 2500;

       
        //#HubUser Create UI elements
        var TenantViewModel = {
            hubUserId: '#hdnHubuserid',
            domainName: '#domainname',
            region: "#region" 
           
            //errorSummary: "#errorSummary",


        }
        //#HubUser Data from UI elements
        var getFormData = function () {
            var newFormData = {};
            newFormData.hubUserId = $(TenantViewModel.hubUserId).val();
            newFormData.domainName = $(TenantViewModel.domainName).val();
            newFormData.region = $(TenantViewModel.region).val();
            return newFormData;
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
                            if (event.target.id === 'tenant-create') {
                                CreateTenant();
                                event.preventDefault()
                            }
                        }
                        form.classList.add('was-validated')
                    }, false)
                })
        })()

    // Create New Tenant        
        var CreateTenant = async function () {
            _utility.toggleSpinner(true);
            var postData = getFormData();
            try {
            var response = await _ajaxHelper.postDataAsync(_hostUrl + "api/Tenants/create", postData);
            if (response.success) {
                    //alert('Tenant created successfully');
                    _utility.toggleSpinner(false);
                     _utility.showAlert("success", "Tenant created successfully", redirectUrl+"home/index", popupTimeOut);
            }
            else {
                //alert("Exception Error :" + response.result);
                    _utility.toggleSpinner(false);
                    _utility.showAlert("error", "Error in creating tenant", null, popupTimeOut);
                }
            }
            catch (error) {
            _utility.toggleSpinner(false);
            _utility.showAlert("error", error, null, popupTimeOut);
            }
        }

    

    }
    catch (error) {
        if (error !== undefined) 
            _utility.showAlert("error", error, null, popupTimeOut);
            _utility.toggleSpinner(false);
    }
 

})();
 