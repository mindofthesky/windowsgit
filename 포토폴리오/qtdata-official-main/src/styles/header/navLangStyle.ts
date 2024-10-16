import styled, { css } from "styled-components";
import { theme } from "../../themes/themes";

export const LangUl = styled.ul`
  display: flex;
  margin-right: 0;
`;

interface LangBtnProps {
  active?: boolean;
}

const activeStyle = css`
  color: ${theme.colors.sub};
`;

export const LangBtn = styled.div<LangBtnProps>`
  margin: 12px;
  font-weight: 700;
  font-size: 16px;
  line-height: 24px;
  color: ${theme.colors.disabled};

  ${(props) => props.active && activeStyle}
`;

export const LangBtnContainer = styled.div`
  display: flex;
  align-items: center;
`;
