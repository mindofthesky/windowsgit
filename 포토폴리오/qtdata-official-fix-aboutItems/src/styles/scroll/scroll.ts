import styled from "styled-components";

interface ScrollToTopButtonContainerProps {
  $visible: boolean;
}

export const ScrollToTopButtonContainer = styled.div<ScrollToTopButtonContainerProps>`
  position: fixed;
  z-index: 9;
  bottom: 410px;
  right: 12%;
  display: ${(props) => (props.$visible ? "block" : "none")};
  transition: opacity 0.3s;
  cursor: pointer;

  @media only screen and (max-width: 800px) {
    display: none;
  }
`;

export const ScrollImg = styled.img`
  width: 48px;
  height: auto;
`;
