import React, { useState } from "react";
import {
  LangBtn,
  LangBtnContainer,
  LangUl,
} from "../../styles/header/navLangStyle";
import { useTranslation } from "react-i18next";

const NavLang = () => {
  const { i18n } = useTranslation();
  const [selectedLang, setSelectedLang] = useState("KR");

  const handleLangClick = (lang: string) => {
    setSelectedLang(lang);
    i18n.changeLanguage(lang);
  };

  return (
    <div>
      <LangUl>
        <LangBtnContainer>
          <li>
            <LangBtn
              role="button"
              active={selectedLang === "KR"}
              onClick={() => handleLangClick("ko")}
            >
              KR
            </LangBtn>
          </li>
          <li>
            <LangBtn
              role="button"
              active={selectedLang === "EN"}
              onClick={() => handleLangClick("en")}
            >
              EN
            </LangBtn>
          </li>
        </LangBtnContainer>
      </LangUl>
    </div>
  );
};

export default NavLang;
