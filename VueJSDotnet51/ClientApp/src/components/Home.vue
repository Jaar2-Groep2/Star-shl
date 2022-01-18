<template>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css">
    <div class="home">
        <div class="img">
            <img src="../assets/star-shl.jpg" />
        </div>

        <iframe width="640" height="360"
                src="https://www.youtube.com/embed/wk-SGVzx1Os">
        </iframe>

        <div class="headline">Over Star-shl</div>

        <div class="text_homepage">
            <editor-content :editor="editor" />
        </div>


        <router-link class="homeButtons btn" :to="{ name: 'Info1' }">
            <i class="bi bi-body-text"></i> Informatie over onderzoeken
        </router-link>
        <router-link class="homeButtons btn" :to="{ name: 'AddReservation' }">
            <i class="bi bi-patch-plus"></i> Afspraak maken
        </router-link>

        <router-link class="homeButtons btn" :to="{ name: 'Priklocaties' }">
            <i class="bi bi-map"></i> Priklokaties
        </router-link>
        <br><br>
    </div>

    <footer class="footer">
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
                        this.contentstring = this.ContentArray[0]["content"];
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
                        id: 1
                    },
                    headers: {
                        'Content-Type': 'application/json',
                        "Access-Control-Allow-Origin": "*",
                        'Access-Control-Allow-Methods': 'GET,PUT,POST,DELETE,PATCH,OPTIONS',
                        'Access-Control-Allow-Credentials': true
                    },
                }).then(function (response) {
                    console.log(response);
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

<style>
    .btn:hover {
        opacity: 1.0;
    }

    .btn {
        color: white;
    }

    body {
        min-height: 100vh;
        padding-bottom: 0;
    }

    footer {
        margin: 8% 0 0 0;
        background: #142d49;
        padding: 4% 4% 2% 4%;
        width: 100%;
        bottom: 0;
    }

    footer p {
        text-align: left;
        font-size: calc(6px + 0.8vw);
    }
</style>

<style scoped>
    img {
        vertical-align: middle;
        border-style: none;
        width: 800px;
        max-width: 90%;
    }

    .text_homepage {
        /*        font-size: calc(8px + 0.5vw);*/
        text-align: center;
        margin-top: 1%;
        margin-left: 8%;
        margin-right: 8%;
    }

    .headline {
        font-size: calc(12px + 1.5vw);
        margin-top: 3%
    }

    .text_homepage h6 {
        cursor: pointer;
        padding: 3%;
        margin-right: 10%;
        margin-left: 10%;
        margin-bottom: 10%;
        box-shadow: 0 0 10px 1px black;
        text-align: left;
        font-size: calc(8px + 1.0vw)
    }

    iframe {
        margin-top: 10px;
        width: 800px;
        max-height:5%;
        max-width: 90%;
    }

    .homeButtons {
        background: #e7334c;
        border: hidden;
        padding: 2%;
        font-size: calc(8px + 1.0vw);
        font-weight: bold;
        width: calc(50% + 1.0vw);
        margin: 1.5%;
    }

    .btn {
        opacity: 1.0;
    }
</style>

