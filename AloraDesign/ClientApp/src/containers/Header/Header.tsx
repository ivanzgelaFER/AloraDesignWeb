import { useDispatch } from "react-redux";
import "./Header.css";
import { useEffect } from "react";
import { Link } from "react-router-dom";
import { ISimpleHeaderItems, getSimpleHeaderItems } from "./HeaderNavigationItems";

export const Header = () => {
    const dispatch = useDispatch();
    const headerItems: ISimpleHeaderItems[] = getSimpleHeaderItems() ?? [];

    const start = (
        <Link id="home-icon" to="/" aria-label="Home page icon">
            <i className="pi pi-home" aria-label="home-page" />
        </Link>
    );

    return (
        <header>
            <div className="menubar">
                {start}
                <nav className={`header-content`}>
                    {headerItems.map(item => {
                        return (
                            <div key={item.link}>
                                <Link className="menu-item" to={item.link} aria-label={item.label}>
                                    <span>{item.label}</span>
                                </Link>
                            </div>
                        );
                    })}
                </nav>
            </div>
        </header>
    );
};
