import styled from 'styled-components';
import { theme } from '../../themes/themes';

export const AboutLeaderInfo = styled.div`
  flex: auto;
  display: flex;
  flex-direction: column;
  padding-top: 20px;
`;

export const AboutLeaderHeadline = styled.div`
  font-weight: 800;
  font-size: 40px;
  line-height: 52px;
  color: ${theme.colors.sub};
`;

export const AboutNameWrap = styled.div`
  align-items: center;
  display: flex;
  -moz-column-gap: 10px;
  column-gap: 10px;
  margin-bottom: 20px;
  margin-top: 20px;
`;

export const AboutName = styled.span`
  font-weight: 800;
  font-size: 28px;
  line-height: 42px;
  color: ${theme.colors.sub};
`;

export const AboutCeo = styled.span`
  font-weight: 600;
  font-size: 28px;
  line-height: 42px;
  color: ${theme.colors.disabled};
`;

export const AboutDetailBox = styled.div`
  width: 500px;
  margin-bottom: 15px;
`;

export const AboutDetail = styled.div`
  /* white-space: pre-wrap; */
  font-weight: 400;
  font-size: 16px;
  line-height: 26px;
  color: ${theme.colors.sub};
`;
