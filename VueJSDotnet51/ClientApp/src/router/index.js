import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import Login from "@/components/Login.vue";
import Database from "@/components/Database.vue";
import SecureComponent from "@/components/Secure.vue"
import PDF from "../components/PDF.vue";
//import Quill from "@/components/Quill.vue";
//import Tiptap from "@/components/Tiptap.vue";
import Edit from "@/components/Edit.vue";


const routes = [
    {
        path: "/Home",
        name: "Home",
        component: Home,
    },
    {
        path: "/Login",
        name: "Login",
        component: Login, 
    },
    {
        path: "/PDF",
        name: "PDF",
        component: PDF,

    },
    {
        path: "/Secure",
        name: "Secure",
        component: SecureComponent,
    },
    {
        path: "/Database",
        name: "Database",
        component: Database,
    },
    {
        path: "/Edit",
        name: "Edit",
        component: Edit
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;