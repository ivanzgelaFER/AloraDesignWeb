import { useSelector } from "react-redux";
import { AppState } from "../../store/configureStore";
import "./HomePage.css";

export const HomePage = () => {
    const user = useSelector((state: AppState) => state.user);

    return (
        <div className="home-container">
            <section className="home-page-section">
                <h1 className="alora-design-title">ALORA DESIGN</h1>
            </section>
            <section className="home-page-section">
                <div className="second-section-container">
                    <div className="">
                        <h2>Učinite najvažniji dan svog života uistinu posebnim!</h2>
                        <div>
                            <p>Reveri po želji kupca</p>
                        </div>
                    </div>
                    <div className="img-container">
                        <img src="./reveri/1.jpg"></img>
                    </div>
                </div>
            </section>
            <section className="home-page-section">
                <div className="second-section-container">
                    <div className="img-container">
                        <img src="./reveri/2.jpg"></img>
                    </div>
                    <div className="">
                        <h2>Tražite li revere po vašoj mjeri, ovo je pravo mjesto za vas!</h2>
                        <div>
                            <p>Ručna izrada i odlična kvaliteta</p>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    );
};
