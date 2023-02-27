"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/cryptoHub").build();

$(function () {
	connection.start().then(function () {

		InvokeData();


	}).catch(function (err) {
		return console.error(err.toString());
	});
});


function InvokeData() {
	connection.invoke("GetCryptoData").catch(function (err) {
		return console.error(err.toString());
	});
}

connection.on("ReceivedData", function (cryptodata) {
	BindDataToGrid(cryptodata);
});

function BindDataToGrid(data) {
	$('#tblCryptoData tbody').empty();

	var tr;
	$.each(data, function (index, data) {
		tr = $('<tr/>');
		tr.append(`<td>${(index + 1)}</td>`);
		tr.append(`<td>${data.name}</td>`);
		tr.append(`<td>${data.icon}</td>`);
		tr.append(`<td>${data.priceandParity}</td>`);
		tr.append(`<td>${data.createDate}</td>`);
		$('#tblCryptoData').append(tr);
	});
}
