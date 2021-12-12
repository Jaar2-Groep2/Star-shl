<template>

    <h2>Uw gegevens</h2>


    <form class="form">

        <div>
            <label for="firstName">Voorletters:</label>
            <input v-model="firstName" name="firstName" id="firstName" type="text" placeholder="Voorletters" />
            <p class="error" v-if="firstName == ''">"Voorletters zijn verplicht</p>
        </div>

        <div>
            <label for="insertion">Tussenvoegsel:</label>
            <input class="insertion_input" v-model="input.insertion" placeholder="Tussenvoegsel" />
        </div>

        <div>
            <label for="lastName">Achternaam:</label>
            <input v-model="lastName" name="lastName" id="lastName" type="text" placeholder="Achternaam" />
            <p class="error" v-if="lastName == ''">"Achternaam is verplicht</p>
        </div>

        <div>
            <label for="email">E-mail:</label>
            <input v-model="email" name="email" id="email" type="email" placeholder="E-mail" />
            <p class="error" v-if="emailCheck">{{ emailError }}</p>
        </div>
            
        <div>
            <label for="phonenumber">Mobiel:</label>
            <input v-model="phonenumber" name="phonenumber" id="phonenumber" type="number" placeholder="Mobiel telefoonnummer" />
            <p class="error" v-if="Number.isNaN(parseInt(form.vat_id))">Voer een geldig nummer in a.u.b</p>
        </div>

        <div>
            <label for="birthdate">Geboortedatum:</label>
            <input v-model="birthdate" name="birthdate" id="birthdate" type="number" placeholder="Geboortedatum" />
        </div>

        <div>
            <label for="gender">Geslacht:</label>
            <select name="gender" v-model="gender">
                <option value="man">man</option>
                <option value="woman">vrouw</option>
            </select>
        </div>

        <button class="btn">Volgende</button>
    </form>

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
    const app = new Vue({
        el: '#app',
        data: {
            firstName: null,
            insertion: null,
            lastName: null,
            email: null,
            emailError: null,
            phonenumber: null,
            birthdate: null,
            gender: null
        },
        methods: {
            emailCheck: function() {
                if (!this.email) {
                    this.emailError = 'Email is een verplicht veld';
                } else if (!this.validEmail(this.email)) {
                    this.emailError = 'Voer aub een geldig email adres in';
                }
                return true;
            },
            validEmail: function (email) {
                var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                return re.test(email);
            }
        }
    })
</script>

<style scoped>
    .form *{
        margin: 3%;
    }

    .form div {
        text-align: left;
    }

    .insertion_input {
        width: 50%;
    }

    .h2{
        margin-bottom: 15%;
    }

    footer {
        bottom: 0;
    }

    .error {
        color: #e7334c;
    }
</style>

