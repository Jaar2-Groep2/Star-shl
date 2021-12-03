﻿import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import Login from "@/components/Login.vue";
import Database from "@/components/Database.vue";
import SecureComponent from "@/components/Secure.vue"
import PDF from "../components/PDF.vue";
import Tiptap from "@/components/Tiptap.vue";
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
        path: "/Tiptap",
        name: "Tiptap",
        component: Tiptap
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;