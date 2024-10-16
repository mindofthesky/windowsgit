import styled from "styled-components";
import { theme } from "../../themes/themes";

export const AgreeContentBox = styled.div`
  max-width: 800px;
  width: 100%;
  margin-bottom: 24px;
  border: 1px solid ${theme.colors.sub};
`;

export const AgreeScrollBox = styled.div`
  overflow-y: auto;
  max-height: 200px;
`;

export const AgreeScrollItem = styled.div`
  padding: 12px;
  font-size: 14px;
`;
