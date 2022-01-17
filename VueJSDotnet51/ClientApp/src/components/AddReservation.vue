<template>
    <h2>Uw gegevens</h2>

    <form>
        <label class="field field_v3">
            <input class="field__input" v-model="form.firstName" name="firstName" id="firstName" type="text" placeholder="e.g. Anna" />
            <span class="field__label-wrap">
                <span class="field__label">Voorletters</span>
                <p class="error">{{ msg['firstName'] }}</p>
            </span>
        </label>

        <label class="field field_v3">
            <input class="field__input" v-model="form.insertion" placeholder="e.g. van den">
            <span class="field__label-wrap">
                <span class="field__label">Tussenvoegsel</span>
            </span>
        </label>

        <label class="field field_v3">
            <input class="field__input" v-model="form.lastName" name="lastName" id="lastName" type="text" placeholder="e.g. Anna" />
            <span class="field__label-wrap">
                <span class="field__label">Achternaam</span>
                <p class="error">{{ msg['lastName'] }}</p>
            </span>
        </label>

        <label class="field field_v3">
            <input class="field__input" v-model="form.email" name="email" id="email" type="email" placeholder="e.g. melnik909@hotmail.nl">
            <span class="field__label-wrap">
                <span class="field__label">E-mail</span>
                <p class="error">{{ msg['email'] }}</p>
            </span>
        </label>

        <label class="field field_v3">
            <input class="field__input" v-model="form.phonenumber" name="phonenumber" id="phonenumber" type="number" min="0" placeholder="e.g. 0612345678" />
            <span class="field__label-wrap">
                <span class="field__label">Mobiel telefoonnummer</span>
            </span>
        </label>

        <label class="field field_v3">
            <input class="field__input" v-model="form.age" type="number" name="age" id="age" min="0" max="130" />
            <span class="field__label-wrap">
                <span class="field__label">Leeftijd</span>
                <p class="error">{{ msg['age'] }}</p>
            </span>
        </label>


        <label class="field field_v1">
            <select class="field__input" name="gender" v-model="form.gender">
                <option value="man">man</option>
                <option value="woman">vrouw</option>
            </select>
            <span class="field__label-wrap">
                <span class="field__label">Geslacht</span>
                <p class="error">{{ msg['gender'] }}</p>
            </span>
        </label>
    </form>

    <div class="btn" style="background-color: #4169E1; margin-top: 5%;" v-on:click="formCheck">Submit</div>

</template>

<script>
    import axios from 'axios'

    export default {
        data() {
            return {
                answer: '',
                emailInfo: [],
                msg: [],
                form: {
                    firstName: '',
                    insertion: '',
                    lastName: '',
                    email: '',
                    phonenumber: '',
                    age: '',
                    gender: ''
                }
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
                if (this.nameCheck(this.form.firstName)) {
                    this.msg['firstName'] = 'Voornaam is verplicht'
                }
                else {
                    this.msg['firstName'] = ''
                }

                if (this.nameCheck(this.form.lastName)) {
                    this.msg['lastName'] = 'Achternaam is verplicht'
                }
                else {
                    this.msg['lastName'] = ''
                }

                if (this.nameCheck(this.form.gender)) {
                    this.msg['gender'] = 'Uw geslacht vermelden is verplicht'
                }
                else {
                    this.msg['gender'] = ''
                }

                if (!/^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(this.form.email)) {
                    this.msg['email'] = 'Voer een geldig email adres in a.u.b'
                }
                else {
                    this.msg['email'] = ''
                }

                if (this.age < 0 || this.form.age > 130) {
                    this.msg['age'] = 'Voer uw echte leeftijd in a.u.b'
                }
                else {
                    this.msg['age'] = ''
                }
                
                if (this.msg['firstName'] == '' && this.msg['lastName'] == '' && this.msg['gender'] == '' && this.msg['email'] == '' && this.msg['age'] == '') {
                    this.sendMail()
                }
            },
            sendMail() {
                let self = this;
                axios({
                    method: 'POST',
                    url: '/api/Email/',
                    data: this.form,
                    headers: {
                        'Content-Type': 'application/json',
                        "Access-Control-Allow-Origin": "*",
                        'Access-Control-Allow-Methods': 'GET,PUT,POST,DELETE,PATCH,OPTIONS',
                        'Access-Control-Allow-Credentials': true
                    },
                }).then(function (response) {
                    console.log(response);
                    self.$router.push({ path: '/EmailSent' })
                }).catch(function (error) {
                    console.log(error);
                    console.log(error.response);
                    alert(error);
                });
            }
        }
    }
</script>


<style scoped>
    .error {
        color: #e7334c;
        font-size: 80%;
    }

    footer {
        margin-top: 10vh;
    }

    .field__input {
        --uiFieldPlaceholderColor: var(--fieldPlaceholderColor, #767676);
        background-color: transparent;
        border-radius: 0;
        border: none;
        -webkit-appearance: none;
        -moz-appearance: none;
        font-family: inherit;
        font-size: inherit;
    }

        .field__input:focus::-webkit-input-placeholder {
            color: var(--uiFieldPlaceholderColor);
        }

        .field__input:focus::-moz-placeholder {
            color: var(--uiFieldPlaceholderColor);
        }

    /*
=====
CORE STYLES
=====
*/

    .field {
        --uiFieldBorderWidth: var(--fieldBorderWidth, 2px);
        --uiFieldPaddingRight: var(--fieldPaddingRight, 1rem);
        --uiFieldPaddingLeft: var(--fieldPaddingLeft, 1rem);
        --uiFieldBorderColorActive: var(--fieldBorderColorActive, rgba(22, 22, 22, 1));
        display: var(--fieldDisplay, inline-flex);
        position: relative;
        font-size: var(--fieldFontSize, 1rem);
    }

    .field__input {
        box-sizing: border-box;
        width: var(--fieldWidth, 100%);
        height: var(--fieldHeight, 3rem);
        padding: var(--fieldPaddingTop, 1.25rem) var(--uiFieldPaddingRight) var(--fieldPaddingBottom, .5rem) var(--uiFieldPaddingLeft);
        border-bottom: var(--uiFieldBorderWidth) solid var(--fieldBorderColor, rgba(0, 0, 0, .25));
    }

        .field__input:focus {
            outline: none;
        }

        .field__input::-webkit-input-placeholder {
            opacity: 0;
            transition: opacity .2s ease-out;
        }

        .field__input::-moz-placeholder {
            opacity: 0;
            transition: opacity .2s ease-out;
        }

        .field__input:focus::-webkit-input-placeholder {
            opacity: 1;
            transition-delay: .2s;
        }

        .field__input:focus::-moz-placeholder {
            opacity: 1;
            transition-delay: .2s;
        }

    .field__label-wrap {
        box-sizing: border-box;
        pointer-events: none;
        cursor: text;
        position: absolute;
        top: 0;
        right: 0;
        bottom: 0;
        left: 0;
    }

        .field__label-wrap::after {
            content: "";
            box-sizing: border-box;
            width: 100%;
            height: 0;
            opacity: 0;
            position: absolute;
            bottom: 0;
            left: 0;
        }

    .field__input:focus ~ .field__label-wrap::after {
        opacity: 1;
    }

    .field__label {
        position: absolute;
        left: var(--uiFieldPaddingLeft);
        top: calc(50% - .5em);
        line-height: 1;
        font-size: var(--fieldHintFontSize, inherit);
        transition: top .2s cubic-bezier(0.9, -0.15, 0.1, 1.15), opacity .2s ease-out, font-size .2s ease-out;
        will-change: bottom, opacity, font-size;
    }

    .field__input:focus ~ .field__label-wrap .field__label,
    .field__input:not(placeholder-shown) ~ .field__label-wrap .field__label {
        --fieldHintFontSize: var(--fieldHintFontSizeFocused, .75rem);
        top: var(--fieldHintTopHover, .25rem);
    }

    /* 
effect 1
*/

    .field_v1 .field__label-wrap::after {
        border-bottom: var(--uiFieldBorderWidth) solid var(--uiFieldBorderColorActive);
        transition: opacity .2s ease-out;
        will-change: opacity;
    }

    /* 
effect 2
*/

    .field_v2 .field__label-wrap {
        overflow: hidden;
    }

        .field_v2 .field__label-wrap::after {
            border-bottom: var(--uiFieldBorderWidth) solid var(--uiFieldBorderColorActive);
            transform: translate3d(-105%, 0, 0);
            will-change: transform, opacity;
            transition: transform .285s ease-out .2s, opacity .2s ease-out .2s;
        }

    .field_v2 .field__input:focus ~ .field__label-wrap::after {
        transform: translate3d(0, 0, 0);
        transition-delay: 0;
    }

    /*
effect 3
*/

    .field_v3 .field__label-wrap::after {
        border: var(--uiFieldBorderWidth) solid var(--uiFieldBorderColorActive);
        will-change: opacity, height;
        transition: height .2s ease-out, opacity .2s ease-out;
    }

    .field_v3 .field__input:focus ~ .field__label-wrap::after {
        height: 100%;
    }

    /*
=====
LEVEL 4. SETTINGS
=====
*/

    .field {
        --fieldBorderColor: #4169E1;
        --fieldBorderColorActive: #191970;
    }

    /*
=====
DEMO
=====
*/

    body {
        font-family: -apple-system, BlinkMacSystemFont, Segoe UI, Roboto, Open Sans, Ubuntu, Fira Sans, Helvetica Neue, sans-serif;
        margin: 0;
        min-height: 100vh;
        display: flex;
        flex-direction: column;
    }

    form {
        box-sizing: border-box;
        width: 100%;
        max-width: 480px;
        margin: 5% auto 0 auto;
        padding: 1rem;
        display: grid;
        grid-gap: 30px;
    }
</style>

