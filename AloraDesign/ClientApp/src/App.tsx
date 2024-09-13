import { HomePage } from "./containers/HomePage/HomePage";
import { Layout } from "./containers/Layout/Layout";
import { configureAxiosClient } from "./api/axiosClient";
import axios from "axios";
import "./App.css";
import { Route, Routes, useLocation } from "react-router-dom";
import { Contact } from "./containers/Contact/Contact";
import { Items } from "./containers/Items/Items";

configureAxiosClient(axios);

export const App = () => {
    const location = useLocation();

    return (
        <Layout>
            <Routes location={location}>
                <Route index path="*" element={<HomePage />} />
                <Route path="/contact" element={<Contact />} />
                <Route path="/items" element={<Items />} />
            </Routes>
        </Layout>
    );
};
