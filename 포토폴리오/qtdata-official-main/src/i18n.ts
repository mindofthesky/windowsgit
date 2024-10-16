import i18n from "i18next";
import { initReactI18next } from "react-i18next";

const resources = {
  en: {
    translation: {
      apply: "Apply",
      title_strategy: "strategy",
    },
  },
  ko: {
    translation: {
      apply: "지원하기",
      title_strategy: "전략기획",
    },
  },
};

i18n.use(initReactI18next).init({
  resources,
  lng: "ko",

  interpolation: {
    escapeValue: false,
  },
});

export default i18n;
