import React, { useState, useEffect } from "react";
import { ScrollImg, ScrollToTopButtonContainer } from "../styles/scroll/scroll";

const ToTopBtn: React.FC = () => {
  const [isVisible, setIsVisible] = useState(false);

  useEffect(() => {
    const handleScroll = () => {
      setIsVisible(window.scrollY > 2500);
    };

    window.addEventListener("scroll", handleScroll);

    return () => {
      window.removeEventListener("scroll", handleScroll);
    };
  }, []);

  const scrollToTop = () => {
    window.scrollTo({
      top: 0,
      behavior: "smooth",
    });
  };

  return (
    <ScrollToTopButtonContainer
      $visible={isVisible}
      onClick={scrollToTop}
      title="to Top"
    >
      <ScrollImg src="/assets/TopBtn.svg" alt="to Top" />
    </ScrollToTopButtonContainer>
  );
};

export default ToTopBtn;
