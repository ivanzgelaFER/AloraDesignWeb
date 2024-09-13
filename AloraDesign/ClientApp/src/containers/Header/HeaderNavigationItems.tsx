import { Dispatch } from "react";
import { NavigateFunction } from "react-router-dom";
import { IntlShape } from "react-intl";

export interface ISimpleHeaderItems {
    link: string;
    label: string;
}

export const getSimpleHeaderItems = (): ISimpleHeaderItems[] => {
    return [
        {
            label: "POČETNA STRANICA",
            link: "/",
        },
        {
            label: "PONUDA",
            link: "/items",
        },
        {
            label: "KONTAKT",
            link: "/contact",
        },
    ];
};
