import React from "react";
import ContentLoader from "react-content-loader";
import styled from "styled-components";

interface LoaderProps {
  loading: boolean;
}

const StyledLoader = styled(ContentLoader)`
  @media (max-width: 800px) {
    width: 100%;
    height: 280px;
  }
`;

const Loader: React.FC<LoaderProps> = ({ loading, ...props }) => {
  return loading ? (
    <StyledLoader
      speed={2}
      width={348}
      height={592}
      viewBox="0 0 348 592"
      backgroundColor="#f3f3f3"
      //   foregroundColor="#ecebeb"
      foregroundColor="#f3f3f3"
      {...props}
    >
      <circle cx="585" cy="667" r="15" />
      <rect x="0" y="373" rx="2" ry="2" width="123" height="20" />
      <rect x="0" y="404" rx="2" ry="2" width="348" height="30" />
      <rect x="0" y="0" rx="6" ry="6" width="348" height="348" />
      <rect x="0" y="446" rx="0" ry="0" width="348" height="67" />
    </StyledLoader>
  ) : null;
};

export default Loader;
