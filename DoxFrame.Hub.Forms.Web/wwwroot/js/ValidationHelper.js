var regularExpression = {
    USPhoneNumber: /\((\d{1,3}[-\)]?)(\s?)\d{3}[-\s]?\d{4}$/,///^\((\d{1,3}[-\)]?)\d{3}[-\s]?\d{4}$/,
    Email: /^([-./#!&+\w\s]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/,
    Name: /^[a-zA-Z\s]+$/,
    Zip: /^[a-zA-Z0-9]{0,10}$/,
    UserName: /^[a-zA-Z0-9_]{6,14}$/,
    Password: /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z!~@#$%^&*()_+=<>\d]{8,25}$/,
    FirstName: /^[a-zA-Z\s\-]?[a-zA-Z\s\-]{2,24}?$/,
    LastName: /^[a-zA-Z\s\-]?[a-zA-Z\s\-]{2,59}?$/,
    City: /^[a-zA-Z ]{2,60}$/,
    Cvv: /^[0-9]{3,4}$/,
    CardNumber: /^[0-9]{15,19}$/,
    MaxDonationAmount: /^[0-9]{1,5}([.][0-9]{1,2})?$/,
    NameWithSpace: /^[a-zA-Z ]*$/,
    Year: /(19[789]\d|20[01]\d)/,
    Money: /^[1-9][0-9]*$/,
    ContinousHyphens: /[-]{2,}/,
    NewUrl: /^[a-zA-Z0-9\-._]?[a-zA-Z0-9\-._]{2,30}?$/,
    Url: /^(https?|s?ftp):\/\/(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$/i,
    PositiveNumbers: /^[+]?([1-9][0-9]*(?:[\.][0-9]*)?|0*\.0*[1-9][0-9]*)(?:[eE][+-][0-9]+)?$/,
    PositiveIntegers: '^[0-9]+$',
    OrderQuantity: /^[1-9]+$/,
    PAN: /^([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}?$/,
    BankAccount: /^[0-9]{7,19}$/g
};

var ValidationHelper = function () {
    var self = this;

    /*Validation Part for individual control*/

    this.ValidateEmail = function (email, ContainsYour) {
        return self.ValidateInfoUsingRegEx(email, regularExpression.Email, 'email', ContainsYour);
    };
    this.ValidatePAN = function (pan, ContainsYour) {
        return self.ValidateInfoUsingRegEx(pan, regularExpression.PAN, 'pan', ContainsYour);
    };
    this.ValidateNameWithLenght = function (pan, ContainsYour) {
        return self.ValidateInfoUsingRegEx(pan, regularExpression.PAN, 'pan', ContainsYour);
    };
    this.validateMaxDonationAmount = function (maxDonationAmount) {
        return self.ValidateInfoUsingRegEx(maxDonationAmount, regularExpression.MaxDonationAmount, 'donation amount');
    }

    this.ValidateCardNumber = function (cardNumber) {
        return self.ValidateInfoUsingRegEx(cardNumber, regularExpression.CardNumber, 'credit card number')
    }

    this.ValidateName = function (name, ContainsYour) {
        return self.ValidateInfoUsingRegEx(name, regularExpression.Name, 'name', ContainsYour);
    };

    this.validateCVV = function (cvv) {
        return self.ValidateInfoUsingRegEx(cvv, regularExpression.Cvv, 'CVV');
    }

    this.ValidateZipCode = function (zipcode, ContainsYour) {
        return self.ValidateInfoUsingRegEx(zipcode, regularExpression.Zip, 'zipcode', ContainsYour)
    }

    this.ValidateUserName = function (userName, ContainsYour) {
        return self.ValidateInfoUsingRegEx(userName, regularExpression.UserName, 'username', ContainsYour)
    }

    this.validatePassword = function (password) {
        return self.ValidateInfoUsingRegEx(password, regularExpression.Password, 'password')
    }

    this.ValidateConfirmationPassword = function (password, ConfirmPassword) {
        return self.ValidatePasswordAgainstConfirmationPasword(password, ConfirmPassword, 'The passwords you entered do not match.')
    }

    this.ValidateFirstName = function (firstName, ContainsYour) {
        if (self.ValidateContinuosHyphensRegEx(firstName, regularExpression.ContinousHyphens, 'first name', ContainsYour).length > 0)
            return self.ValidateContinuosHyphensRegEx(firstName, regularExpression.FirstName, 'first name', ContainsYour)
        else
            return self.ValidateInfoUsingRegEx(firstName, regularExpression.FirstName, 'first name', ContainsYour)
    }

    this.ValidateCardholderName = function (cardholderName, title, ContainsYour) {
        return self.ValidateInfoUsingRegEx(cardholderName, regularExpression.NameWithSpace, title, ContainsYour)
    }

    this.ValidateLastName = function (lastName, ContainsYour) {
        if (self.ValidateContinuosHyphensRegEx(lastName, regularExpression.ContinousHyphens, 'last name', ContainsYour).length > 0)
            return self.ValidateContinuosHyphensRegEx(lastName, regularExpression.FirstName, 'last name', ContainsYour)
        else
            return self.ValidateInfoUsingRegEx(lastName, regularExpression.LastName, 'last name', ContainsYour)
    }

    this.ValidateDRPValues = function (drpValue) {
        return self.ValidateAllDropDownValues(drpValue, 'value')
    }

    this.ValidatePhoneNumber = function (phoneNumber, ContainsYour) {
        return self.ValidateInfoUsingRegEx(phoneNumber, regularExpression.USPhoneNumber, 'phone number', ContainsYour)
    }

    this.ValidateMoney = function (money) {
        return self.ValidateInfoUsingRegEx(money, regularExpression.Money, "goal amount")
    }
    this.IsNullOrUndefinedOrEmpty = function (value) {
        return (value === null || value === undefined || value.length === 0 || $.trim(value).lenth === 0 )
    };
    this.IsNotValidId = function (value) {
        return (value === null || value == 0 || value === undefined || $.trim(value).lenth === 0)
    };
    this.ValidateYear = function (value, ContainsYour) {
        return self.ValidateInfoUsingRegEx(value, regularExpression.Year, 'year', ContainsYour)
    };

    this.ValidateCity = function (value, ContainsYour) {
        return self.ValidateInfoUsingRegEx(value, regularExpression.City, "city", ContainsYour)
    };

    this.ValidateBankName = function (BankName) {
        return self.ValidateInfoUsingRegEx(BankName, regularExpression.BankName, 'bank name')
    }

    this.ValidateBankAccount = function (BankAccount) {
        return self.ValidateInfoUsingRegEx(BankAccount, regularExpression.BankAccount, 'bank account number')
    }
    this.ValidatePrice = function (price) {
        return self.ValidatePriceUsingRegEx(price, regularExpression.PositiveNumbers)
    }
    this.ValidatePositiveIneger = function (value) {
        return self.ValidatePositiveIntUsingRegEx(value, regularExpression.PositiveIntegers)
    };
    this.ValidateOrderQuantity = function (value) {
        return regularExpression.OrderQuantity.test(value);
    };
    /*Generic Validation Part for individual control*/
    this.ValidateInfoUsingRegEx = function (inputValue, regEx, controlTitle, ContainsYour) {

        ContainsYour = ContainsYour || '';

        if (self.IsNullOrUndefinedOrEmpty(inputValue)) {
            return "Please enter " + ContainsYour + ' ' + controlTitle;
        }
        else if (!regEx.test(inputValue)) {
            return "Please enter valid " + controlTitle;
        }
        else if (inputValue <= 0) {
            return "Please enter valid " + controlTitle;
        }
        else {
            return "";
        }
        return errorMessage;
    };

    this.ValidateContinuosHyphensRegEx = function (inputValue, regEx, controlTitle, ContainsYour) {

        ContainsYour = ContainsYour || '';

        if (self.IsNullOrUndefinedOrEmpty(inputValue)) {
            return "Please enter " + ContainsYour + ' ' + controlTitle;
        }
        else if (regEx.test(inputValue)) {
            return "Please enter valid " + controlTitle;
        }
        else if (inputValue <= 0) {
            return "Please enter valid " + controlTitle;
        }
        else {
            return "";
        }
        return errorMessage;
    };

    this.ValidatePasswordAgainstConfirmationPasword = function (password, confirmPassword, controlTilte) {
        if (confirmPassword === null || confirmPassword === undefined || confirmPassword.length === 0) {
            return controlTilte + " Please enter the password.";
        }
        else if (password != confirmPassword) {
            return controlTilte + "Please check them and try again.";
        }
        else {
            return "";
        }
    }

    this.RequiredValue = function (value, field, containsYour) {
        containsYour = containsYour || '';
        if (value.length == 0) {
            return "Please enter " + containsYour + '' + field;
        }
        else {
            return "";
        }
    }

    this.isCountySelected = function (value, containsYour) {
        containsYour = containsYour || '';
        if (value.length == 0) {
            return "Please select " + containsYour + " country";
        }
        else {
            return "";
        }
    }

    this.isStateSelected = function (value, containsYour) {
        containsYour = containsYour || '';
        if (value.length == 0) {
            return "Please select " + containsYour + " state";
        }
        else {
            return "";
        }
    }

    this.ValidateAllDropDownValues = function (drpValue, controlTitle) {
        // containsYour = containsYour || '';
        if (drpValue <= 0) {
            return "Please select " + controlTitle;
        }
        else {
            return "";
        }
    }

    this.CheckDefaultValue = function (ControlData, CompareToValue) {
        if (ControlData == CompareToValue) {
            return "";
        }
        else {
            return ControlData;
        }
    }

    this.IsUrlValid = function (url, control) {
        if (!regularExpression.Url.test(url)) {
            return " Please enter valid " + control + " url";
        }
        else
            return "";
    };

    this.IsValidSocialURL = function (url, control) {
        if (!regularExpression.NewUrl.test(url)) {
            return " Please enter valid " + control + " username";
        }
        else
            return "";
    };
    this.ValidatePriceUsingRegEx = function (inputValue, regEx) {

        //    ContainsYour = ContainsYour || '';

        if (self.IsNullOrUndefinedOrEmpty(inputValue)) {
            return "Please enter Price";
        }
        else if (!regEx.test(inputValue)) {
            return "Please enter valid Price";
        }
        else {
            return "";
        }
        return errorMessage;
    };
    this.ValidatePositiveIntUsingRegEx = function (inputValue, regEx) {
        //    ContainsYour = ContainsYour || '';

        if (self.IsNullOrUndefinedOrEmpty(inputValue)) {
            return "Please enter number";
        }
        else if (!regEx.test(inputValue)) {
            return "Please enter number";
        }
        else {
            return "";
        }
        return errorMessage;
    };
    this.ShowError = function (controlSelector, errorMessage) {
        $(controlSelector).html(errorMessage);
        $(controlSelector).css('display', 'block');
    };

    this.HideError = function (controlSelector) {
        $(controlSelector).css('display', 'none');
    };

    this.GetQueryParameter = function (name, url) {
        if (!url) url = window.location.href;
        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, " "));
    };
    this.GetQueryID = function (name, url) {
        if (!url) url = window.location.href;
        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);
        if (!results) return 0;
        if (!results[2]) return '';
        var paramValue = decodeURIComponent(results[2].replace(/\+/g, " "));
        if (this.IsNullOrUndefinedOrEmpty(paramValue))
            return 0;
        else
            return parseInt(paramValue);
    };

    this.ScrollToError = function (scrollToControl = undefined) {
        try {
            scrollToControl = this.IsNullOrUndefinedOrEmpty(scrollToControl) ? '.error' : scrollToControl;
            var errorLoc = $(`${scrollToControl}:visible`).first();
            var scrollPos = errorLoc.offset().top - 250;
            $('.widgets-wrapper').scrollTop(scrollPos);
        } catch (e) {
            console.log(e);
        }
    };
    this.ValidateTextBox = function (controlSelection, errorLabelSelector, errorMessage) {
        if (self.IsNullOrUndefinedOrEmpty($(controlSelection).val())) {
            self.ShowError(errorLabelSelector, errorMessage);
            return 1;
        } else {
            self.HideError(errorLabelSelector);
            return 0;
        }
    }
    this.ValidateDropdown = function (controlSelection, errorLabelSelector, errorMessage) {
        if (self.IsNullOrUndefinedOrEmpty($(controlSelection).val()) || $(controlSelection + ' :selected').val() == '0' || $(controlSelection + ' :selected').val() == '-1') {
            self.ShowError(errorLabelSelector, errorMessage);
            return 1;
        } else {
            self.HideError(errorLabelSelector, errorMessage);
            return 0;
        }
    }

    this.formatDate = function (dateInput, format = 'dmy') {
        var result = '';
        var month = dateInput.getMonth() + 1;
        var day = dateInput.getDate();
        var year = dateInput.getFullYear().toString();
        day = (day < 10) ? '0' + day : day;
        month = (month < 10) ? '0' + month : month;
        try {
            switch (format) {
                default:
                case 'ydm':
                    result = `${year}/${day}/${month} ${this.formatAMPM(dateInput)}`;
                    break;
                case 'ymd':
                    result = `${year}/${month}/${day} ${this.formatAMPM(dateInput)}`;
                    break;
                case 'mdy':
                    result = `${month}/${day}/${year} ${this.formatAMPM(dateInput)}`;
                    break;
                case 'myd':
                    result = `${month}/${year}/${day} ${this.formatAMPM(dateInput)}`;
                    break;
                case 'dmy':
                    result = `${day}/${month}/${year} ${this.formatAMPM(dateInput)}`;
                    break;
                case 'dym':
                    result = `${day}/${year}/${month} ${this.formatAMPM(dateInput)}`;
                    break;
            }
        } catch (ex) {
            console.log(ex);
        }
        return result;
    }

    this.formatAMPM = function (date) {
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var ampm = hours >= 12 ? 'PM' : 'AM';
        hours = hours % 12;
        hours = hours ? (hours < 10) ? '0' + hours : hours : 12; // the hour '0' should be '12'
        minutes = minutes < 10 ? '0' + minutes : minutes;
        var strTime = hours + ':' + minutes + ' ' + ampm;
        return strTime;
    }

    this.formatDateFromString = function (stringDate, format = 'ydm') {
        if (stringDate.indexOf('-') != -1)
            stringDate = stringDate.replace(/\-/g, '/').replace(/\.{d}/g, '/');
        if (stringDate.indexOf('.') != -1)
            stringDate = stringDate.substring(0, stringDate.indexOf('.'));
        var newDate = new Date(stringDate);
        if (_helper.IsNullOrUndefinedOrEmpty(newDate) || newDate.toString() == 'Invalid Date')
            return stringDate;
        else
            return this.formatDate(newDate, format);
    }
    this.allowIntegersOnly = function (event) {
        if (event.shiftKey == true) {
            event.preventDefault();
        }

        if ((event.keyCode >= 48 && event.keyCode <= 57) ||
            (event.keyCode >= 96 && event.keyCode <= 105) ||
            event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 37 ||
            event.keyCode == 39 || event.keyCode == 46) {

        } else {
            event.preventDefault();
        }
    }
    this.allowDecimalsOnly = function (event) {
        if (event.shiftKey == true) {
            event.preventDefault();
        }

        if ((event.keyCode >= 48 && event.keyCode <= 57) ||
            (event.keyCode >= 96 && event.keyCode <= 105) ||
            event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 37 ||
            event.keyCode == 39 || event.keyCode == 46 || event.keyCode == 190) {

        } else {
            event.preventDefault();
        }

        if ($(this).val().indexOf('.') !== -1 && event.keyCode == 190)
            event.preventDefault();
        //if a decimal has been added, disable the "."-button
    }

    this.GetNewGUID = function () {
        return ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, c =>
            (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
        )
    }

    this.ShowErrorInSummary = function (summarySelector, errorMessage, controlSelector) {
        var error_msg = `<div class='error_msg' data-item='${controlSelector}'>
                    <i class='material-icons'>error_outline</i>
                    <span class='msg'>${errorMessage}</span>
                </div>`;
        $(summarySelector).append(error_msg);
        $(summarySelector).parent().show();
        var errorLabel = $(controlSelector).siblings('i.validation_icon')[0];
        if (!this.IsNullOrUndefinedOrEmpty(errorLabel)) {
            $(errorLabel).show();
        }
        this.ScrollToError('.error_msg');
    }

    this.HideErrorInSummary = function (summarySelector) {
        $('.validation_icon').hide();
        $(summarySelector).html('');
        $(summarySelector).parent().hide();
    };
    this.RemoveErrorAndHideErrorInSummary = function (summarySelector, controlSelector, tabSelector = null) {
        $(summarySelector).find("[data-item='" + controlSelector + "']").remove();
        var errorLabel = $(controlSelector).siblings('i')[0];
        if (!this.IsNullOrUndefinedOrEmpty(errorLabel))
            $(errorLabel).hide();
        var errormsg = $(summarySelector).find('.error_msg');
        if (errormsg.length > 0) {
            $(summarySelector).parent().show();
        } else {
            $(summarySelector).parent().hide();
        }
        if (!this.IsNullOrUndefinedOrEmpty(tabSelector)) {
            var tabDivId = $('#productInfo').attr('href');
            if (!this.IsNullOrUndefinedOrEmpty(tabDivId)) {
                var otherErrors = $(tabDivId).find('i').is(':visible');
                if (!otherErrors)
                    $(tabSelector).removeClass("tab_error");
            }
        }
    };
    this.RemoveErrorInSummary = function (summarySelector, controlSelector) {
        $(summarySelector).find("[data-item='" + controlSelector + "']").remove();
        var errormsg = $(summarySelector).find('.error_msg');
        if (errormsg.length > 0) {
            $(summarySelector).parent().show();
        } else {
            $(summarySelector).parent().hide();
        }
        ;
    }
    this.GetIntValue = function (strValue) {
        var numberInfo = parseInt(strValue);
        if (isNaN(numberInfo) || this.IsNullOrUndefinedOrEmpty(strValue))
            return 0;
        else
            return numberInfo;
    };
    this.GetFloatValue = function (strValue) {
        var numberInfo = parseFloat(strValue);
        if (isNaN(numberInfo) || this.IsNullOrUndefinedOrEmpty(strValue))
            return 0.0;
        else
            return numberInfo;
    };
    this.IsValidIntValue = function (strValue) {
        var numberInfo = parseInt(strValue);
        if (isNaN(numberInfo) || this.IsNullOrUndefinedOrEmpty(strValue) || numberInfo === 0)
            return false;
        else
            return true;
    };
    this.DestroyGridIfExists = function (controlSelection) {
        try {
            var grid = $(controlSelection).data("kendoGrid");
            if (!this.IsNullOrUndefinedOrEmpty(grid)) {
                $(controlSelection).data("kendoGrid").destroy();
            }
        } catch (e) {
            console.log(e);
        }
    }

}
