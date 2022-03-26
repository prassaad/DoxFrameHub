 
var _hostUrl = '';
(function (){
  
    try {
        var _ajaxHelper = new AjaxHelper();
        var _utility = new Utility();
        _hostUrl = _utility.GetHostUrl();
        var redirectUrl = _hostUrl;
        var popupTimeOut = 2500;


       
        //#HubUser Create UI elements
        var HubUserViewModel = {
            email: '#email',
            name: '#name',
            mobile: "#mobile",
            type: "#type"
            //errorSummary: "#errorSummary",


        }
        //#HubUser Data from UI elements
        var getFormData = function () {
            var newFormData = {};
            newFormData.email = $(HubUserViewModel.email).val();
            newFormData.name = $(HubUserViewModel.name).val();
            newFormData.mobile = $(HubUserViewModel.mobile).val();
            newFormData.type = $(HubUserViewModel.type).prop('checked');
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
                            if (event.target.id === 'account-create') {
                                CreateHubUser();
                                event.preventDefault()
                            }
                        }
                        form.classList.add('was-validated')
                    }, false)
                })
        })()

    // Create New HubUser        
    var CreateHubUser = async function () {
            _utility.toggleSpinner(true);
            var postData = getFormData();
        try {
            var response = await _ajaxHelper.postDataAsync(_hostUrl + "api/HubUsers/create", postData);
            if (response.success) {
                 // alert('Account created successfully');
                _utility.toggleSpinner(false);
                _utility.showAlert("success", "Account created successfully", redirectUrl, popupTimeOut);

                  }
            else {
                //alert("Exception Error :" + response.result);
                    _utility.toggleSpinner(false);
                    _utility.showAlert("error", "There is an error in creating account", null, popupTimeOut);
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
            _utility.togglePageLoader(false);
    }
 

})();
 