import styled from "styled-components";
import { theme } from "../../themes/themes";

export const NavBar = styled.div`
  display: flex;
  float: right;
  margin-right: 300px;

  @media only screen and (max-width: 800px) {
    display: none;
  }

  @media only screen and (max-width: 1280px) {
    margin-left: 66px;
    margin-right: 55px;
  }

  @media only screen and (max-width: 900px) {
    margin-left: 36px;
    margin-right: 25px;
  }
`;

export const NavUl = styled.ul`
  display: flex;
  font-weight: 700;
  font-size: 20px;
  line-height: 28px;
  opacity: 1;
  color: ${theme.colors.disabled};

  @media only screen and (max-width: 1280px) {
    font-size: 14px;
    line-height: 24px;
  }
`;

export const NavList = styled.li`
  display: flex;
  align-items: center;
  margin-left: 24px;
  cursor: pointer;

  &:first-child {
    margin-left: 0 !important;
  }

  @media only screen and (max-width: 1280px) {
    margin-left: 8px;

    &:first-child {
      margin-left: 0 !important;
    }
  }

  @media only screen and (max-width: 1280px) {
    margin-left: 1px;

    &:first-child {
      margin-left: 0 !important;
    }
  }
`;

export const IconWrap = styled.div`
  width: 16px;
  height: 16px;
  margin-left: 8px;
`;

export const IconImg = styled.img`
  width: 16px;
  height: 16px;
`;
