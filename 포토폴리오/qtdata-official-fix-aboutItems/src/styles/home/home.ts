import styled from "styled-components";

export const HomeLayout = styled.div`
  overflow-y: auto;
  overflow-x: hidden;
`;

export const HomeWrap = styled.div`
  width: 100vw;
`;

export const HiddenDiv = styled.div`
  display: none;
  width: 100%;
  height: 8px;

  @media only screen and (max-width: 800px) {
    display: block;
  }
`;
