
var AjaxHelper = function () {
    getErrorResponse = function (error) {
        var response = new Object();
        response.Success = false,
            response.Payload = null,
            response.ErrorMessage = error.statusText;
        return response;
    };
    this.getDataV1 = function (url) {
        var result;
        $.ajax({
            'async': false,
            'global': false,
            'url': url,
            'success': function (response) {
                result = response;
            },
            'error': function (error) {
            }
        });
        return result;
    };
    this.getData = function (url) {
        var result = '';
        $.ajax({
            'async': false,
            'global': false,
            'url': url,
            'success': function (response) {
                result = response;
            },
            'error': function (error) {
                result = getErrorResponse(error);
            }
        });
        return result;
    };
    this.getDataByParams = function (url, params) {
        var result = '';
        $.ajax({
            'async': false,
            'global': false,
            'url': url,
            'type': 'GET',
            'data': params,
            'success': function (response) {
                result = response;
            },
            'error': function (error) {
                result = getErrorResponse(error);
            }
        });
        return result;
    };
    this.addItem = function (url, item) {
        var result = '';
        $.ajax({
            'async': false,
            'global': false,
            url: url,
            contentType: 'application/json; charset=utf-8',
            type: 'post',
            dataType: "json",
            data: JSON.stringify(item),
            success: function (response) {
                result = response;
            },
            error: function (response) {
                result = getErrorResponse(response);
            }
        });
        return result;
    };
    this.updateItem = function (url, item) {
        var result = '';
        $.ajax({
            'async': false,
            'global': false,
            url: url,
            contentType: 'application/json; charset=utf-8',
            type: 'post',
            data: JSON.stringify(item),
            success: function (response) {
                result = response;
            },
            error: function (response) {
                result = getErrorResponse(response);
            }
        });
        return result;
    };
    this.deleteItem = function (url, id) {
        var result = '';
        $.ajax({
            'async': false,
            'global': false,
            url: url,
            contentType: 'application/json; charset=utf-8',
            type: 'post',
            data: JSON.stringify(id),
            success: function (response) {
                result = response;
                //location.reload();
            },
            error: function (response) {
                result = getErrorResponse(response);
            }
        });
        return result;
    };
    this.GetApiUrl = function (areaName) {
        var result = '';
        $.ajax({
            'async': false,
            'global': false,
            'url': '/build/service/GetSchema',
            data: { 'path': "/Packages.json" },
            'success': function (response) {
                var packageList = JSON.parse(response);
                $.each(packageList.Data[0].ModulesList, function (index, item) {
                    if (item.PackageName.toLowerCase() === areaName.toLowerCase()) {
                        result = item.ServiceHostUrl;
                    }
                });
            },
            'error': function (error) {
                result = getErrorResponse(error);
            }
        });
        return result;
    };
    this.postData = function (url, parameters) {
        var result = '';
        $.ajax({
            'async': false,
            'global': false,
            url: url,
            contentType: 'application/json; charset=utf-8',
            type: 'post',
            dataType: 'json',
            data: parameters,
            success: function (response) {
                result = response;
            },
            error: function (response) {
                result = getErrorResponse(response);
                console.log(response.responseText.toString());
            }
        });
        return result;
    }
    this.getDataByKey = function (url, isAsync) {
        var result = '';
        $.ajax({
            'async': isAsync,
            'global': false,
            'url': url,
            'type': 'GET',
            'success': function (response) {
                result = response;
            },
            'error': function (error) {
                result = getErrorResponse(error);
            }
        });
        return result;
    };
    this.updateItemWithPut = function (url, item) {
        var result = '';
        $.ajax({
            'async': false,
            'global': false,
            url: url,
            contentType: 'application/json; charset=utf-8',
            type: 'put',
            data: JSON.stringify(item),
            success: function (response) {
                result = response.value;
            },
            error: function (response) {
                result = getErrorResponse(response);
            }
        });
        return result;
    };
    this.CheckIfRecordExists = function (url) {
        var result = false;
        $.ajax({
            'async': false,
            'global': false,
            url: url,
            contentType: 'application/json; charset=utf-8',
            type: 'get',
            success: function (response) {
                result = response.value.length > 0;
            },
            error: function (response) {
                result = getErrorResponse(response);
            }
        });
        return result;
    };
    //#region AsyncCallbacks
    this.getDataAsyn = function (url, callback) {
        $.ajax({
            'global': false,
            'url': url,
            'success': callback,
            'error': callback

        });
    };

    this.getDataByParamsAsyn = function (url, params, callback) {
        $.ajax({
            'global': false,
            'url': url,
            'type': 'GET',
            'data': params,
            'success': callback,
            // 'error': errorCallback
            'error': callback
        });
    };
    this.getDataByPostParams = function (url, params) {
        var result = '';
        $.ajax({
            'async': false,
            'global': false,
            'url': url,
            'type': 'GET',
            'data': params,
            'contentType': 'application/json; charset=utf-8',
            'dataType': 'json',
            'success': function (response) {
                result = response;
            },
            'error': function (error) {
                result = getErrorResponse(error);
            }
        });
        return result;
    };
    //this.getDataAsyn = function (url, successCallback, data) {
    //    $.ajax({
    //        'async': false,
    //        'global': false,
    //        'url': url,
    //        'success':
    //            function () {
    //                successCallback(data, textStatus, xhr)
    //            },
    //        // 'error': errorCallback
    //        'error':
    //            function () {
    //                successCallback(textStatus, xhr, errorThrown)
    //            }

    //    });
    //};

    this.getDataAsync = async function (url) {

        let result;

        try {
            result = await $.ajax({
                url: url,
                type: 'GET',
            });

            return result;
        } catch (error) {
            return result;
        }
    };

    this.postDataAsync = async function (url, data) {

        let result;

        try {
            result = await $.ajax({
                url: url,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify(data),
                dataType: "json"

            });
            return result;
        } catch (error) {
            console.error(error);
        }
    };

    this.postDataAsync = async function (url, data, needToStringfy = true) {
        let result;
        let dataToPost = '';
        if (needToStringfy) {
            dataToPost = JSON.stringify(data);
            dataToPost = dataToPost.replace(new RegExp(',{}', "gi"), '');
        }
        try {
            result = await $.ajax({
                url: url,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: needToStringfy ? dataToPost : data,
                dataType: "json"

            });
            return result;
        } catch (error) {
            console.error(error);
        }
    };

    this.getDataByParamsAsync = async function (url, params, methodType) {
        let result;

        try {
            result = await $.ajax({
                url: url,
                type: methodType,
                contentType: 'application/json; charset=utf-8',
                'data': params,
                dataType: "json"

            });
            return result;
        } catch (error) {
            console.error(error);
        }
    };

    this.GetApiUrlsAsyn = async function () {
        let result;
        try {
            result = await $.ajax({
                'url': '/build/service/GetSchema',
                data: { 'path': "/Packages.json" },
                type: 'GET',
            });
            return result;
        } catch (error) {
            console.error(error);
        }
    };
    this.ApiCallWithAUthorize = function (url, item) {
        var result = '';
        $.ajax({
            'async': false,
            'global': false,
            url: url,
            contentType: 'application/json; charset=utf-8',
            type: 'post',
            dataType: "json",
            data: JSON.stringify(item),
            success: function (response) {
                result = response;
            },
            error: function (response) {
                result = getErrorResponse(response);
            },
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", "Bearer " + localStorage.getItem("Token"));
            }
        });
        return result;
    };
    this.getDataAsynWithAuth = function (url, callback) {
        $.ajax({
            'global': false,
            'url': url,

            'success': callback,
            'error': callback,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", "Bearer " + localStorage.getItem("Token"));
            }

        });
    };
    this.getAuthDataAsync = async function (url) {
        let result;
        try {
            result = await $.ajax({
                url: url,
                type: 'GET',
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Bearer " + localStorage.getItem("Token"));
                }
            });
            return result;
        } catch (error) {
            return result;
        }
    };
    this.PostItem = function (url, item) {

        let result;

        try {
            result = $.ajax({
                url: url,
                headers: { 'Access-Control-Allow-Origin': 'http://localhost:5000', "Access-Control-Allow-Methods": "GET, POST,PUT" },
                contentType: 'application/json; charset=utf-8',
                type: 'post',
                dataType: "json",
                data: JSON.stringify(item)
            });

            return result;
        } catch (error) {
            console.error(error);
        }

    };

    //#endregion
    //#region AsyncGetDataWithPromise
    this.AsyncGetDataWithPromise = function (url) {
        return new Promise(function (resolve, reject) {
            var xhr = new XMLHttpRequest();
            xhr.onload = function () {
                resolve(this.responseText);
            };
            xhr.onerror = reject;
            xhr.open('GET', url);
            xhr.send();
        });
    };
    this.addItemWithAuth = function (url, item) {
        var result = '';
        $.ajax({
            'async': false,
            'global': false,
            url: url,
            contentType: 'application/json; charset=utf-8',
            type: 'post',
            dataType: "json",
            data: JSON.stringify(item),
            success: function (response) {
                result = response;
            },
            error: function (response) {
                result = getErrorResponse(response);
            },
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', "Bearer " + localStorage.getItem("Token"));
            }
        });
        return result;
    };
    this.updateItemWithAuth = function (url, item) {
        var result = '';
        $.ajax({
            'async': false,
            'global': false,
            url: url,
            contentType: 'application/json; charset=utf-8',
            type: 'post',
            data: JSON.stringify(item),
            success: function (response) {
                result = response;
            },
            error: function (response) {
                result = getErrorResponse(response);
            },
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', "Bearer " + localStorage.getItem("Token"));
            }
        });
        return result;
    };
    this.getDataWithAuth = function (url) {
        var result = '';
        $.ajax({
            'async': false,
            'global': false,
            'url': url,
            success: function (response) {
                result = response;
            },
            error: function (error) {
                result = getErrorResponse(error);
            },
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', "Bearer " + localStorage.getItem("Token"));
            }
        });
        return result;
    };
    this.DeleteItemWithAuth = function (apiurl, callback) {
        var result = '';
        $.ajax({
            'async': false,
            'global': false,
            type: 'DELETE',
            'url': apiurl,
            data: {},
            'success': callback,
            'error': callback
        });
        return result;
    };
    //#endregion
};