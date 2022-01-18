<template>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link type="text/css" rel="stylesheet" href="css/materialize.min.css" media="screen,projection" />
    <div class="home">
        <div class="img">
            <img src="../assets/star-shl.jpg" />
        </div>
        <div>
            <router-link class="sezer btn" :to="{ name: 'Info1' }">Over Star-shl</router-link>
            <router-link class="sezer btn" :to="{ name: 'Info2' }">Innovatie</router-link>
        </div>
        <div>
            <router-link class="sezer btn" :to="{ name: 'Info3' }">Vrijwilligersbeleid</router-link>
            <router-link class="sezer btn" :to="{ name: 'Info4' }">Kwaliteit</router-link>
        </div>

        <div class="text_info">
            <editor-content :editor="editor" />
        </div>
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
    import axios from 'axios'
    import { Editor, EditorContent } from '@tiptap/vue-3'
    import StarterKit from '@tiptap/starter-kit'

    export default {
        components: {
            EditorContent,
        },

        data() {
            return {
                editor: null,
                ContentArray: [],
                DBcontent: "",
                contentstring: ""
            }
        },

        methods: {
            GetContent() {
                axios.get("/api/content")
                    .then((response) => {
                        this.ContentArray = response.data;
                        this.contentstring = this.ContentArray[3]["content"];
                        this.editor.commands.setContent(this.contentstring);
                    })
                    .catch(function (error) {
                        console.log(error);
                        alert(error);
                    }
                    );

            },

            saveInDB() {
                const html = this.editor.getHTML();
                axios({
                    method: 'PUT',
                    url: "/api/content",
                    data: {
                        content: html,
                        id: 4
                    },
                    headers: {
                        'Content-Type': 'application/json',
                        "Access-Control-Allow-Origin": "*",
                        'Access-Control-Allow-Methods': 'GET,PUT,POST,DELETE,PATCH,OPTIONS',
                        'Access-Control-Allow-Credentials': true
                    },
                }).then(function (response) {
                    console.log(response);
                    window.alert("Opgeslagen!");
                }).catch(function (error) {
                    console.log(error);
                    console.log(error.response);
                    alert(error);
                });
            },
        },

        mounted() {
            this.editor = new Editor(
                {
                    editable: false,
                    extensions: [
                        StarterKit,
                    ],
                    content: 'test '
                }),
                this.GetContent();
        },

        beforeUnmount() {
            this.editor.destroy()
        },
    }
</script>

<style scoped>
    .text_info {
        /*        font-size: calc(8px + 0.5vw);*/
        text-align: center;
        margin-top: 1%;
        margin-left: 8%;
        margin-right: 8%;
    }
    .sezer {
        background: #e7334c;
        border: hidden;
        padding: 2%;
        font-size: calc(6px + 1.0vw);
        font-weight: bold;
        width: calc(30% + 1.0vw);
        margin: 1.5%;
    }

    .ProseMirror p {
        margin: 10em 0;
        text-align: center;
    }

    img {
        vertical-align: middle;
        border-style: none;
        width: 800px;
        max-width: 90%;
    }

    .save_class {
        margin-bottom: 1%;
        margin-top: 1%;
    }

    .blue {
        background: #2C2B64;
    }

    .edit_buttons {
        margin-top: 1%;
    }

    .btn_save {
        background: rgb(111 216 103);
        border: hidden;
        padding: 1%;
        font-size: calc(60% + 2vw);
        /*border-radius: 15px;*/
        width: calc(30% + 1.5vw);
        margin: 1.5%;
        font-weight: 500;
        text-decoration-color: white;
        color: white;
    }

    .bub {
        color: rgb(18 33 82);
    }

    .material-icons {
        font-size: 10px;
    }
</style>

