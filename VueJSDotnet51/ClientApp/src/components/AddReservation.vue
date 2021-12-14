<template>

    <div class="form">
        <h2>Uw gegevens</h2>

        <div>
            <label>Voorletters:</label>
            <input v-model="input.firstName" placeholder="Voorletters" />
        </div>

        <div>
            <label>Tussenvoegsel:</label>
            <input class="insertion_input" v-model="input.insertion" placeholder="Tussenvoegsel" />
        </div>

        <div>
            <label>Achternaam:</label>
            <input v-model="input.lastname" placeholder="Achternaam" />
        </div>

        <div>
            <label>E-mail:</label>
            <input v-model="input.mail" placeholder="E-mail" />
        </div>

        <div>
            <label>Mobiel:</label>
            <input v-model="input.phonenumber" id="number" placeholder="Mobiel telefoonnummer" />
        </div>

        <div>
            <label>Geslacht:</label>
            <select name="gender" v-model="gender">
                <option value="man">man</option>
                <option value="woman">vrouw</option>
            </select>
        </div>

        <button class="btn" onclick="errorMessage()">Volgende</button>
    </div>

    <footer>
        <p class="text-white">
            <strong>Etten-Leur</strong><br>
            Bredaseweg 165, 4872 LA<br>
            Postbus 228, 4870 AE<br>
            <br>
            <strong>Rotterdam</strong><br>
            Vlambloem 21, 3068 JE<br>
            Postbus 8661, 3009 AR<br>
        </p>
    </footer>
</template>


<script>
    export default {
        data() {
            return {
                input: {
                    firstName: "",
                    insertion: "",
                    lastName: "",
                    mail: "",
                    phonenumber: "",
                    birthdate: "",
                    gender: ""
                }
            }
        }

        //werkt nog niet
        //errorMessage() {
        //    var error = document.getElementById("error")
        //    error.textContent = "Please enter a valid number"
        //    error.style.color = "red"
        //}
    }
</script>

<style scoped>
    .form * {
        margin: 3%;
    }

    .form div {
        text-align: left;
    }

    .insertion_input {
        width: 50%;
    }

    .form h2 {
        margin-bottom: 15%;
    }

    footer {
        bottom: 0;
    }
</style>

