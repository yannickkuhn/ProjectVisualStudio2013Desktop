﻿// variables globales
var loading;
var content;
function faireSimulation() {
    // d'abord les références sur le DOM
    var formulaire = $("#formulaire");
    // ensuite validation du formulaire
    if (!formulaire.validate().form()) {
        // formulaire invalide - terminé
        return;
    }
    // on fait un appel Ajax à la main
    $.ajax({
        url: '/Pam/FaireSimulation',
        type: 'POST',
        data: formulaire.serialize(),
        dataType: 'html',
        beforeSend: function() {
            loading.show();
        },
        success: function (data) {
            loading.hide();
            simulation.html(data);
            simulation.show();
        },
        error: function (jqXHR) {
            // affichage erreur
            simulation.html(jqXHR.responseText);
            simulation.show();
        }
    });
    // menu
    setMenu([lnkEffacerSimulation, lnkVoirSimulations, lnkEnregistrerSimulation, lnkTerminerSession]);
}
function effacerSimulation() {
    // on efface les saisies du formulaire
    var formulaire = $("#formulaire");

    // Inputs du formulaire
    var HeuresTravaillées = $('input[name="HeuresTravaillées"]');
    var JoursTravaillés = $('input[name="JoursTravaillés"]');

    formulaire.validate().form();

    HeuresTravaillées.val("");
    JoursTravaillés.val("");

    // on cache la div de simulation
    if(simulation != null)
        simulation.hide();

    // menu
    setMenu([lnkFaireSimulation, lnkEffacerSimulation, lnkVoirSimulations, lnkTerminerSession]);
}
function enregistrerSimulation() {
    // on fait un appel Ajax à la main
    $.ajax({
        url: '/Pam/EnregistrerSimulation',
        type: 'POST',
        dataType: 'html',
        begin: loading.show(),
        success: function (data) {
            loading.hide();
            content.html(data);
            setMenu([lnkRetourFormulaire, lnkTerminerSession]);
        }
    })
}
function voirSimulations() {
    // on fait un appel Ajax à la main
    $.ajax({
        url: '/Pam/VoirSimulations',
        type: 'POST',
        dataType: 'html',
        begin: loading.show(),
        success: function (data) {
            loading.hide();
            content.html(data);
            setMenu([lnkRetourFormulaire, lnkTerminerSession]);
        }
    })
}
function retourFormulaire() {
    // on fait un appel Ajax à la main
    $.ajax({
        url: '/Pam/Formulaire',
        type: 'POST',
        dataType: 'html',
        begin: loading.show(),
        success: function (data) {
            loading.hide();
            content.html(data);
            simulation.show();
            setMenu([lnkFaireSimulation, lnkVoirSimulations, lnkTerminerSession]);
        },
        complete: function () {
            // important : validation
            $.validator.unobtrusive.parse($("#formulaire"));
        }
    })
}
function terminerSession() {
    // on fait un appel Ajax à la main
    $.ajax({
        url: '/Pam/TerminerSession',
        type: 'POST',
        dataType: 'html',
        beforeSend: function() {
            loading.show();
        },
        success: function (data) {
            loading.hide();
            content.html(data);
            setMenu([lnkFaireSimulation, lnkVoirSimulations, lnkTerminerSession]);
        },
        complete: function () {
            // important : validation
            $.validator.unobtrusive.parse($("#formulaire"));
        }

    })
}
function retirerSimulation(N) {
    // on fait un appel Ajax à la main
    $.ajax({
        url: '/Pam/RetirerSimulation',
        type: 'POST',
        data: "num=" + N,
        dataType: 'html',
        beforeSend: function() {
            loading.show();
        },
        success: function (data) {
            loading.hide();
            content.html(data);
        }
    });
    // menu
    setMenu([lnkRetourFormulaire, lnkTerminerSession]);
}

// variables globales
var loading;
var content;
var lnkFaireSimulation;
var lnkEffacerSimulation
var lnkEnregistrerSimulation;
var lnkTerminerSession;
var lnkVoirSimulations;
var lnkRetourFormulaire;
var options;

function setMenu(show) {
    for (i = 0 ; i < options.length ; i++) {
        options[i].hide();
    }
    for (i = 0 ; i < show.length ; i++) {
        show[i].show();
    }
}

// au chargement du document
$(document).ready(function () {

    // on récupère les références des différents composants de la page
    loading = $("#loading");
    content = $("#content");
    simulation = $("#simulation");

    lnkFaireSimulation = $("#lnkFaireSimulation");
    lnkEffacerSimulation = $("#lnkEffacerSimulation");
    lnkEnregistrerSimulation = $("#lnkEnregistrerSimulation");
    lnkVoirSimulations = $("#lnkVoirSimulations");
    lnkTerminerSession = $("#lnkTerminerSession");
    lnkRetourFormulaire = $("#lnkRetourFormulaire");
    // on les met dans un tableau
    options = [lnkFaireSimulation, lnkEffacerSimulation, lnkEnregistrerSimulation, lnkVoirSimulations, lnkTerminerSession, lnkRetourFormulaire];
    // on cache certains éléments de la page
    loading.hide();
    // on fixe le menu
    setMenu([lnkFaireSimulation, lnkVoirSimulations, lnkTerminerSession]);

});