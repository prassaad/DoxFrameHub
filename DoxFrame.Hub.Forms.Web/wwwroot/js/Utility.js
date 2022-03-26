var ResourceName = "";
var HostUrl = "https://localhost:44302/";
var Utility = function () {

    this.GetHostUrl = function () {
        return HostUrl;
    }

    this.showAlert = function (alertType, alertMessage, redirectUrl, timeout) {
        $("#divAlert").show();
        switch (alertType.toLowerCase()) {
            case "success":
                $("#divAlert").addClass('alert alert-success alert-dismissible fade show');
                break;
            case "error":
                $("#divAlert").addClass('alert alert-dange alert-dismissible fade show');
                break;
            case "warning":
                $("#divAlert").addClass('alert alert-warning alert-dismissible fade show');
                break;
            case "info":
                $("#divAlert").addClass('alert alert-primary alert-dismissible fade show');
                break;
        }
        $("#alertText").text(alertMessage)
        $("#divAlert").show();
        setTimeout(function () {
            $("#txtAlertMessage").text("")
            $("#divAlert").hide();
        }, timeout);
        if (!this.IsNullOrUndefinedOrEmpty(redirectUrl))
            setTimeout(function () { window.location.href = redirectUrl; }, timeout);
    }
    this.showAlertWithoutReload = function (alertType, alertMessage, timeout) {
        switch (alertType) {
            case "success":
                $("#divSuccessShow").addClass('alert-success');
                $("#txtSuccessMessage").text(alertMessage)
                $("#divSuccessShow").show();
                setTimeout(function () {
                    $("#txtSuccessMessage").text("")
                    $("#divSuccessShow").hide();
                }, timeout);
                break;
            case "error":
                $("#txtErrorMessage").text(alertMessage)
                $("#divErrorShow").show();
                setTimeout(function () {
                    $("#txtErrorMessage").text("")
                    $("#divErrorShow").hide();
                }, timeout);
                break;
            case "warning":
                $("#txtWarningsMessage").text(alertMessage)
                $("#divWarningShow").show();
                setTimeout(function () {
                    $("#txtWarningsMessage").text("")
                    $("#divWarningShow").hide();
                }, timeout);
                break;
            case "info":
                $("#txtInfoMessage").text(alertMessage)
                $("#divInfoShow").show();
                setTimeout(function () {
                    $("#txtInfoMessage").text("")
                    $("#divInfoShow").hide();
                }, timeout);
                break;
        }
    }
    this.IsNullOrUndefinedOrEmpty = function (value) {
        return value === null || value === undefined || value.length === 0;
    };
   
    this.toggleSpinner = function (isshow) {
        if (isshow) {
            // $('#divSpinner').show();
            $("#divSpinner").removeClass("d-none");
            $("#divSpinner").addClass("d-block");
        }
        else {
           // $('#divSpinner').hide();
            $("#divSpinner").addClass("d-none");
            $("#divSpinner").removeClass("d-block");

        }
    }
    this.getCurrentDate = function (date, format) {
        switch (format.toUpperCase()) {
            case "DD/MM/YYYY":
                return `${("0" + date.getDate()).slice(-2)}/${("0" + (date.getMonth() + 1)).slice(-2)}/${date.getFullYear()}`;
                break;
            case "MM/DD/YYYY":
                return `${("0" + (date.getMonth() + 1)).slice(-2)}/${("0" + date.getDate()).slice(-2)}/${date.getFullYear()}`;
                break;
            case "YYYY/MM/DD":
                return `${date.getFullYear()}/${("0" + (date.getMonth() + 1)).slice(-2)}/${("0" + date.getDate()).slice(-2)}`;
                break;
            case "DD MON YYYY":
                var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL",
                    "AUG", "SEP", "OCT", "NOV", "DEC"];
                return `${("0" + date.getDate()).slice(-2)} ${months[date.getMonth()]} ${date.getFullYear()}`;
                break;
            case "DD/MM/YYYY HH:MM":
                return `${("0" + date.getDate()).slice(-2)}/${("0" + (date.getMonth() + 1)).slice(-2)}/${date.getFullYear()} ${("0" + (date.getHours())).slice(-2)}:${("0" + (date.getMinutes())).slice(-2)}`;
                break;
            case "YYYY/MM/DD HH:mm":
                return `${date.getFullYear()}/${("0" + (date.getMonth() + 1)).slice(-2)}/${("0" + date.getDate()).slice(-2)} ${("0" + (date.getHours())).slice(-2)}:${("0" + (date.getMinutes())).slice(-2)}`;
                break;
            default:
                return `${date.getDate()}/${(date.getMonth() + 1)}/${date.getFullYear()}`;
                break;
        }
    }
    this.GetTwoDigitValue = function (value) {
        try {
            return this.IsNullOrUndefinedOrEmpty(value) ? '0.00' : value > 0 ? (Math.round(value * 100) / 100).toFixed(2) : '0.00';
        } catch (ex) {
            console.log(ex);
            return '0.00';
        }
    }
    this.BindLoginCompanyDepartments = async function (selector, companyid, functionType = null, selectedValue = "") {
        try {
            selectedValue = (this.IsNullOrUndefinedOrEmpty(selectedValue) || selectedValue == "0" || selectedValue === 0) ? "" : selectedValue;
            var _ajaxHelper = new AjaxHelper();
            var _orgApiHelper = new OrgApiHelper();
            var _hostUrl = _ajaxHelper.GetApiUrl(this.APIAreaNames.Organization);
            $(selector).empty();
            $(selector).append(new Option("--Please Select--", ""));
            var departments = await _ajaxHelper.getDataByParamsAsync(_hostUrl + _orgApiHelper.DepartmentApi.getDepartmentsByCompany, { id: companyid, functionalType: functionType });
            if (departments != undefined && departments != null && departments.Payload != null && departments.Payload != null) {
                $.each(departments.Payload, function (index, value) {
                    $(selector).append($("<option></option>").val(value.OrganizationUnitId).html(value.DeptName));
                });
            }
        }
        catch (e) {
            console.log(e);
        }
        $(selector).val(selectedValue);
    };
  
    this.ValidateActionPermission = function (permClaim = 0, docResource) {
        try {
            // var permParam = JSON.stringify({ "PermissionClaim": permClaim, UserId: userId });
            var positionInfo = this.LoginCompanyInfo();
            var userId = $('#txtAuthenticatedUserId').val();
            var positionId = (positionInfo != null && positionInfo != undefined && positionInfo != "") ? (positionInfo.position != null && positionInfo.position != undefined && positionInfo.position != "") ? parseInt(positionInfo.position) : 1 : 1;
            var permParam = JSON.stringify({ PermissionId: permClaim, UserId: userId, PositionId: positionId, DocResource: docResource });
            var _ajaxHelper = new AjaxHelper();
            var _orgApiHelper = new OrgApiHelper();
            var _hostUrl = _ajaxHelper.GetApiUrl(this.APIAreaNames.Organization);
            var response = _ajaxHelper.postData(_hostUrl + _orgApiHelper.UserRolesAndPositions.ValidateClaim, permParam);
            if (!this.IsNullOrUndefinedOrEmpty(response)) {
                if (response.Success) {
                    return response.Payload;
                }
                else
                    return false;
            }
            else
                return false;
        } catch (e) {
            console.log(e);
            return false;
        }
    };
    this.GetDocumentAccessInfo = async function (docResource) {
        try {
            var positionInfo = this.LoginCompanyInfo();
            var userId = $('#txtAuthenticatedUserId').val();
            var positionId = (positionInfo != null && positionInfo != undefined && positionInfo != "") ? (positionInfo.position != null && positionInfo.position != undefined && positionInfo.position != "") ? parseInt(positionInfo.position) : 1 : 1;
            var permParam = JSON.stringify({ UserId: userId, PositionId: positionId, DocResource: docResource });
            var _ajaxHelper = new AjaxHelper();
            var _orgApiHelper = new OrgApiHelper();
            var _hostUrl = _ajaxHelper.GetApiUrl(this.APIAreaNames.Organization);
            var response = await _ajaxHelper.postDataAsync(_hostUrl + _orgApiHelper.UserRolesAndPositions.DocumentAccessByResource, permParam, false);
            if (!this.IsNullOrUndefinedOrEmpty(response)) {
                if (response.Success) {
                    return response.Payload;
                }
                else
                    return null;
            }
            else
                return null;
        } catch (e) {
            console.log(e);
            return null;
        }
    };
    this.getDocumentInfoAsync = function (resource) {
        ResourceName = resource;
        var result = "";
        var _orgHostAPIURL = _ajaxHelper.GetApiUrl(this.APIAreaNames.Organization);
        $.ajax({
            'async': false,
            'global': false,
            url: _orgHostAPIURL + 'api/v1/ByResourceName?resource=' + resource,
            contentType: false,
            type: 'get',
            // processData: false,
            // data: formData,
            success: function (response) {
                if (response != null) {
                    result = response.Payload[0].isApprovalRequired;
                    if (result != null && result == false) {
                        $("#Approveprocess").hide();
                    }

                }

            },

        });
        // return result;

    };
    this.getUserDateFormat = async function () {
        if (localStorage.getItem("user_dateFormat") === undefined || localStorage.getItem("user_dateFormat") === null) {
            //to call after the login
            var _ajaxHelper = new AjaxHelper();
            let _hostAPIURL = _ajaxHelper.GetApiUrl(this.APIAreaNames.Organization);
            let _orgApiHelper = new OrgApiHelper();
            var filtercondition = `SystemSettingsShortCode eq 'Organization.DateFormat'`;
            var SystemSettingAPIURL = `${_hostAPIURL + _orgApiHelper.SystemSettings.GetSystemSettings}?$Filter=${filtercondition}&$select=Value,SettingControlTypeId,SystemSettingsShortCode,SystemSettingsId&$TOP=1`;
            var response = _ajaxHelper.getDataWithAuth(SystemSettingAPIURL);
            var SettingObj = response.value;
            if (SettingObj != null && SettingObj != undefined && SettingObj.length > 0) {
                var lookupId = parseInt(SettingObj[0].Value);
                if (!isNaN(lookupId) && lookupId > 0) {
                    var SystemSettingsValueAPIURL = `${_hostAPIURL + _orgApiHelper.SystemSettingsValues.getSystemSettingvalues}?$Filter=SystemSettingsValuesId eq ${lookupId}&$Select=Value`;
                    var response = _ajaxHelper.getDataWithAuth(SystemSettingsValueAPIURL);
                    if (response.value !== undefined && response.value != null) {
                        localStorage.setItem("user_dateFormat", response.value[0].Value);
                    }
                }
            }
        }
    }
};
 