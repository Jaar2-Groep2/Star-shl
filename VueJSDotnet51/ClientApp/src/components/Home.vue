<template>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    import './styles/my-styles.scss'
    <link type="text/css" rel="stylesheet" href="css/materialize.min.css" media="screen,projection" />


    <div class="home">
        <div class="img">
            <img src="../assets/star-shl.jpg" />
        </div>

        <video controls="controls" preload="metadata">
            <source src="../assets/WatGebeurtErMetBloed.mp4#t=3.5" type="video/mp4">
            Your browser does not support the video tag.
        </video>

        Text_saver

                <a class="homeButtons btn">Informatie over onderzoeken</a>
                <a class="homeButtons btn">Afspraak maken</a>
                <a class="homeButtons btn">Priklocaties</a>
                <br><br>
                <a class="homeButtons blue btn">Contact</a>
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
    //import { Editor, EditorContent } from '@tiptap/vue-3'
    //import StarterKit from '@tiptap/starter-kit'

    //export default {
    //    components: {
    //        EditorContent,
    //    },

    //    data() {
    //        return {
    //            editor: null,
    //        }
    //    },

    //    mounted() {
    //        this.editor = new Editor({
    //            content: '<h5>Iedereen die bij ons komt, heeft vragen over gezondheid. Vragen die wij beantwoorden met betrouwbare medische diagnostiek. Achter elke diagnose schuilt een persoonlijk verhaal. Daarom geloven wij dat elke vraag onze speciale aandacht verdient voor een helder en betrouwbaar antwoord.</h5>',
    //            extensions: [
    //                StarterKit,
    //            ],
    //        })
    //    },

    //    beforeUnmount() {
    //        this.editor.destroy()
    //    },
    //}
</script>

<style>
    .btn:hover {
        opacity: 0.6;
    }

    .btn {
        color: white;
    }
</style>

<style scoped>
    .ProseMirror p {
        margin: 10em 0;
        text-align: center;
    }
    .img {
        vertical-align: middle;
        border-style: none;
    }
    img {
        vertical-align: middle;
        border-style: none;
        width: 800px;
        max-width: 90%;
    }

    img {
        vertical-align: middle;
        border-style: none;
        width: 800px;
        max-width: 80%;
    }

    .text_homepage {
        font-size: 60%;
        text-align: center;
        margin-top: 1%;
        margin-bottom: 3%;
        margin-left: 15%;
        margin-right: 15%;
    }

    .text_homepage p {
        cursor: pointer;
        padding: 4%;
        margin-right: 10%;
        margin-left: 10%;
        margin-bottom: 12%;
        border-radius: 15px;
        box-shadow: 0 0 10px 1px black;
        text-align: left;
    }

    video {
        margin-top: 10px;
        width: 640px;
        height: 360px;
    }   


    @media screen and (max-width: 700px) {
        video {
            width: 320px;
            margin-top: 10px;
            height: 240px;
        }
    }

    .homeButtons {
        background: #E91E63;
        border: hidden;
        padding: 2%;
        font-size: 60%;
        border-radius: 15px;
        width: 60%;
        margin: 1.5%;
    }

    .blue {
        background: #2C2B64;
    }

    footer {
        margin-top: 5%;
        background: #2C2B64;
        padding: 5%;
        padding-left: 8%;
    }

    footer p {
        text-align: left;
        font-size: 50%;
    }

    .btn {
        opacity: 0.6;
    }
    .edit_buttons {
        margin-top: 3%;
    }
    .bub {
        color: rgb(18 33 82);
    }
    .material-icons {
        font-size: 10px;
    }

</style>

<!--<style lang="scss">
/* Basic editor styles */
.ProseMirror {
  > * + * {
    margin-top: 0.75em;
  }

  ul,
  ol {
    padding: 0 1rem;
  }

  h1,
  h2,
  h3,
  h4,
  h5,
  h6 {
    line-height: 1.1;
  }

  code {
    background-color: rgba(#616161, 0.1);
    color: #616161;
  }

  pre {
    background: #0D0D0D;
    color: #FFF;
    font-family: 'JetBrainsMono', monospace;
    padding: 0.75rem 1rem;
    border-radius: 0.5rem;

    code {
      color: inherit;
      padding: 0;
      background: none;
      font-size: 0.8rem;
    }
  }

  img {
    max-width: 100%;
    height: auto;
  }

  blockquote {
    padding-left: 1rem;
    border-left: 2px solid rgba(#0D0D0D, 0.1);
  }

  hr {
    border: none;
    border-top: 2px solid rgba(#0D0D0D, 0.1);
    margin: 2rem 0;
  }
}
</style>-->
