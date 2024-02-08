$(function () {
    var l = abp.localization.getResource("LocationService");
	
	var userLocationService = window.sTS.locPoC.locationService.userLocations.userLocations;
	
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "UserLocations/CreateModal",
        scriptUrl: abp.appPath + "Pages/UserLocations/createModal.js",
        modalClass: "userLocationCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "UserLocations/EditModal",
        scriptUrl: abp.appPath + "Pages/UserLocations/editModal.js",
        modalClass: "userLocationEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            userIdMin: $("#UserIdFilterMin").val(),
			userIdMax: $("#UserIdFilterMax").val(),
			longitude: $("#LongitudeFilter").val(),
			latitude: $("#LatitudeFilter").val()
        };
    };
    
    
    
    var dataTableColumns = [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('LocationService.UserLocations.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('LocationService.UserLocations.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    userLocationService.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reloadEx();;
                                        });
                                }
                            }
                        ]
                },
                width: "1rem"
            },
			{ data: "userId" },
			{ data: "longitude" },
			{ data: "latitude" }        
    ];
    
    

    var dataTable = $("#UserLocationsTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: true,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(userLocationService.getList, getFilter),
        columnDefs: dataTableColumns
    }));
    
    

    createModal.onResult(function () {
        dataTable.ajax.reloadEx();;
    });

    editModal.onResult(function () {
        dataTable.ajax.reloadEx();;
    });

    $("#NewUserLocationButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });

	$("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reloadEx();;
    });

    $("#ExportToExcelButton").click(function (e) {
        e.preventDefault();

        userLocationService.getDownloadToken().then(
            function(result){
                    var input = getFilter();
                    var url =  abp.appPath + 'api/location-service/user-locations/as-excel-file' + 
                        abp.utils.buildQueryString([
                            { name: 'downloadToken', value: result.token },
                            { name: 'filterText', value: input.filterText },
                            { name: 'userIdMin', value: input.userIdMin },
                            { name: 'userIdMax', value: input.userIdMax }, 
                            { name: 'longitude', value: input.longitude }, 
                            { name: 'latitude', value: input.latitude }
                            ]);
                            
                    var downloadWindow = window.open(url, '_blank');
                    downloadWindow.focus();
            }
        )
    });

    $('#AdvancedFilterSectionToggler').on('click', function (e) {
        $('#AdvancedFilterSection').toggle();
    });

    $('#AdvancedFilterSection').on('keypress', function (e) {
        if (e.which === 13) {
            dataTable.ajax.reloadEx();;
        }
    });

    $('#AdvancedFilterSection select').change(function() {
        dataTable.ajax.reloadEx();;
    });
    
    
    
    
    
    
    
    
});
