<template>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <!--Import materialize.css-->
    <link type="text/css" rel="stylesheet" href="css/materialize.min.css" media="screen,projection" />

    <div id="Secure">
        <img src="../assets/star-shl.jpg" />
    
    <div class="headline">
        <h2 style="font-size:6vw">Medewerkersportaal</h2>
    </div>
    
    </div>
    <div class="Reservation_add Reservations">
        <a class="btn">
            <i class="material-icons">add_circle</i> Reservering toevoegen
        </a>
    </div>
    <div class="Reservation_delete Reservations">
        <a class="btn">
            <i class="material-icons">delete</i> Reservering verwijderen
        </a>
    </div>

    <div class="reservation_check Reservations">
        <a class="btn">
            <i class="material-icons">visibility</i> Reserveringen inzien
        </a>
    </div>


        <div class="Editable_infopage Reservations">
            <a class="btn">
                <i class="material-icons">edit</i>Informatiepagina bewerken
            </a>
        </div>

        <div class="Editable_homepage Reservations">
            <a class="btn">
                <i class="material-icons">edit</i>Homepagina bewerken
            </a>
        </div>


</template>


<script>

    document.addEventListener('DOMContentLoaded', function () {
        var elems = document.querySelectorAll('.dropdown-trigger');
        var options = {alignment: 'left'}
        this.Dropdown.init(elems, options);
    });


</script>

<style scoped>
    #Secure {
    }
    img {
        vertical-align: middle;
        border-style: none;
        width: 60%;
        margin-bottom: 3%
    }

    .Reservations a i {
        font-size: 16px;
    }

    .Reservations a {
        background: #e91e63;
        border: hidden;
        font-size: 50%;
        border-radius: 15px;
        width: 60%;
        margin: 2%;
    }
    .Reservation_add{
        opacity: 0.2;
    }
    .Reservation_delete{
        opacity: 0.2;
    }
    .Editable_homepage a {
    
        opacity: 0.2;
        background: #00c853;
    }

    .Editable_infopage a {
        opacity: 0.2;
        background: #00c853;
    }
</style>