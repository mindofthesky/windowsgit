import React from "react";
import {
  FooterWrap,
  FooterLayout,
  FooterContainer,
  FooterContact,
} from "../../styles/footer/footer";
import FooterLeft from "./FooterLeft";
import FooterRight from "./FooterRight";

const Footer = () => {
  return (
    <FooterLayout>
      <FooterWrap>
        <FooterContainer>
          <FooterLeft />
          <FooterRight />
        </FooterContainer>
        <div>
          <FooterContact>
            Copyright 2024. QUANTUMDATA Inc. All rights reserved.
          </FooterContact>
        </div>
      </FooterWrap>
    </FooterLayout>
  );
};

export default Footer;
