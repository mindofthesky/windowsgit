import styled from "styled-components";
import { theme } from "../../themes/themes";

export const MobileIcon = styled.div`
  position: relative;
  z-index: 10;
  display: none;

  @media (max-width: 800px) {
    display: flex;
    position: relative;
    justify-content: space-between;
    margin-right: 20px;
  }
`;

export const MobileMenu = styled.ul`
  position: absolute;
  top: 0;
  left: 0;
  display: none;
  flex-direction: column;
  justify-content: center;
  width: 100%;
  padding-bottom: 12px;
  background-color: ${theme.colors.white};

  &.visible {
    display: flex;
  }
`;

export const MobileItemBox = styled.div`
  @media only screen and (max-width: 800px) {
    bottom: 0;
    width: 100%;
  }
`;

export const MobileMenuItem = styled.li`
  display: block;
  padding: 18px 24px;
  font-size: 14px;
  font-weight: 500;
  line-height: normal;
  color: ${theme.colors.disabled};
`;

export const MobileMenuLogo = styled.div`
  display: block;
  width: 233px;
  height: 30px;
  margin-bottom: 0.25rem;
  background-position: center;
  background-repeat: no-repeat;
  image-rendering: -moz-crisp-edges;
  image-rendering: -o-crisp-edges;
  image-rendering: -webkit-optimize-contrast;
  image-rendering: crisp-edges;
  -ms-interpolation-mode: nearest-neighbor;
  transform: translateZ(0);
  backface-visibility: hidden;
  background-image: url(/assets/footerLogo.svg);

  @media only screen and (max-width: 800px) {
    width: 95px;
    height: 30px;
    margin-top: 15px;
    margin-left: 20px;
    margin-bottom: 15px;
    background-size: 100%;
  }
`;

export const MobileCopy = styled.p`
  margin-top: 20px;
  font-weight: 500;
  font-size: 12px;
  line-height: 14px;
  color: ${theme.colors.disabled};
`;

export const Micon = styled.img`
  width: 24px;
  height: 24px;
`;
