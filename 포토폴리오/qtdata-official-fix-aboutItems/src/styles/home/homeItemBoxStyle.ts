import styled from "styled-components";
import { theme } from "../../themes/themes";

export const HomeItemContainer = styled.div`
  display: flex;
  align-items: center;
  flex-direction: column;
  width: 218px;
  text-align: center;

  @media only screen and (max-width: 800px) {
    display: flex;
    -moz-column-gap: 30px;
    column-gap: 30px;
    width: 250px;
    margin-bottom: 40px;

    &:first-child {
      margin-top: 150px;
    }
  }
`;

export const HomeItemImgBox = styled.div`
  margin-bottom: 60px;
  line-height: 32px;

  @media only screen and (max-width: 800px) {
    margin-bottom: 20px;
  }
`;

export const HomeItemImg = styled.img<{ imageSize?: string }>`
  @media only screen and (max-width: 800px) {
    width: ${(props) => props.imageSize || "100%"};
  }
`;

export const HomeItemTitleBox = styled.div`
  height: 64px;
  margin-bottom: 20px;
  font-size: 16px;

  @media only screen and (max-width: 800px) {
    width: auto;
    height: auto;
  }
`;

export const HomeItemTitle = styled.span`
  white-space: pre-wrap;
  font-weight: 700;
  font-size: 24px;
  line-height: 32px;
  color: ${theme.colors.sub};

  @media only screen and (max-width: 800px) {
    font-size: 12px;
  }
`;

export const HomeItemDecsBox = styled.div`
  line-height: 28px;
`;
