<template>
    <link rel="stylesheet" href="trumbowyg/dist/ui/trumbowyg.min.css">

    <div id="Edit">
        <h3>
            Vue Trumbowyg demo
        </h3>
        <trumbowyg v-model="content" :config="config" class="editor" @tbw-blur="onBlur"></trumbowyg>
        <pre>
        {{content}}
        </pre>
    </div>

</template>

<script >
    //uncomment keybind is ctrl + k + u
    //comment keybind is ctrl + k + c
    import Trumbowyg from 'vue-trumbowyg';  // do not know exactly what it does
    import 'trumbowyg/dist/ui/trumbowyg.css';   //css of trumbowyg
    import $ from 'jquery'  //jquery

    //$('#editor').trumbowyg(); //if you comment this out you can see the page
    //$('#trumbowyg-demo').trumbowyg({                  -   if you comment this out you can see the page
    //    btns: [['strong', 'em',], ['insertImage']],
    //    autogrow: true
    //});

    export default {
        name: "Edit",
        data() {
            return {
                content: '<h1>Test</h1>',
                config: {
                    //http://alex-d.github.io/Trumbowyg/documentation.html#basic-options

                }
            }
        },
        components: {
            //Trumbowyg: VueTrumbowyg.default // Trumbowyg not defined error
              //Trumbowyg: Edit.default // Trumbowyg not defined error
            Trumbowyg

        },
        mounted() {
            console.log('app mounted')      // code under mounted() does not do anything
            $('#editor').trumbowyg();
            $('#desc').Trumbowyg();
            $('#trumbowyg-demo').trumbowyg({
                btns: [['strong', 'em',], ['insertImage']],
                autogrow: true
            });
        },
        methods: {
            onBlur(e) {
                console.log("blur", e)
            }
        }
    }//).mount("#Edit"); // do not know what this does, looks like mounted function does noet work because .mount is commented

    //$('#desc').Trumbowyg(); if you comment this out you can see the page
</script>


<style>
    body {
        background: #f8f8f8
    }

    pre {
        background: #ddd;
        padding: 10px
    }
</style>