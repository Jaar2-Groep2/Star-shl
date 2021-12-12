<template>

    <h2>Uw gegevens</h2>


    <form class="form">

        <div>
            <label for="firstName">Voorletters:</label>
            <input v-model="firstName" name="firstName" id="firstName" type="text" placeholder="Voorletters*" />
            <p class="error">{{ msg['firstName'] }}</p>
        </div>

        <div>
            <label for="insertion">Tussenvoegsel:</label>
            <input class="insertion_input" v-model="insertion" placeholder="Tussenvoegsel" />
        </div>

        <div>
            <label for="lastName">Achternaam:</label>
            <input v-model="lastName" name="lastName" id="lastName" type="text" placeholder="Achternaam*" />
            <p class="error">{{ msg['lastName'] }}</p>
        </div>

        <div>
            <label for="email">E-mail:</label>
            <input v-model="email" name="email" id="email" type="email" placeholder="E-mail*" />
            <p class="error">{{ msg['email'] }}</p>
        </div>

        <div>
            <label for="phonenumber">Mobiel:</label>
            <input v-model="phonenumber" name="phonenumber" id="phonenumber" type="number" placeholder="Mobiel telefoonnummer" />
            <p class="error"></p>
        </div>

        <div>
            <label for="age">Leeftijd:</label>
            <input id="age" v-model="age" type="number" name="age" min="0" max="130">
            <p class="error">{{ msg['age'] }}</p>
        </div>

        <div>
            <label for="gender">Geslacht:</label>
            <select name="gender" v-model="gender">
                <option value="man">man</option>
                <option value="woman">vrouw</option>
            </select>
            <p class="error">{{ msg['gender'] }}</p>
        </div>

        <div class="btn" v-on:click="formCheck">Submit</div>
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
    export default {
        data() {
            return {
                msg: [],
                firstName: '',
                insertion: '',
                lastName: '',
                email: '',
                phonenumber: null,
                age: null,
                gender: ''
            }
        },
        methods: {
            nameCheck: function(name) {
                if (name == '') {
                    return true
                }
                else {
                    return false
                }
            },
            formCheck() {
                if (this.nameCheck(this.firstName)) {
                    this.msg['firstName'] = 'Voornaam is verplicht'
                }
                else {
                    this.msg['firstName'] = ''
                }

                if (this.nameCheck(this.lastName)) {
                    this.msg['lastName'] = 'Achternaam is verplicht'
                }
                else {
                    this.msg['lastName'] = ''
                }

                if (this.nameCheck(this.gender)) {
                    this.msg['gender'] = 'Uw geslacht vermelden is verplicht'
                }
                else {
                    this.msg['gender'] = ''
                }

                if (!/^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(this.email)) {
                    this.msg['email'] = 'Voer een geldig email adres in a.u.b'
                }
                else {
                    this.msg['email'] = ''
                }

                if (this.age < 0 || this.age > 130) {
                    this.msg['age'] = 'Voer uw echte leeftijd in a.u.b'
                }
                else {
                    this.msg['age'] = ''
                }
                
                if (this.msg['firstName'] == '' && this.msg['lastName'] == '' && this.msg['gender'] == '' && this.msg['email'] == '' && this.msg['age'] == '') {
                    this.$router.replace({ name: "Secure" });
                }
            }
        }
    }
</script>

<style scoped>
    .form div {
        margin: 10%;
        text-align: left;
    }

    .form div label {
        margin-right: 2%;
    }

    .insertion_input {
        width: 50%;
    }

    .h2 {
        margin-bottom: 15%;
    }

    footer {
        margin-top: 10vh;
    }

    .error {
        color: #e7334c;
    }
</style>

