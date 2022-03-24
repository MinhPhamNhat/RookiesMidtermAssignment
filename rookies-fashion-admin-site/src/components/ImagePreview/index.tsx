import React from "react";
const ImagePreview: React.FC<any> = ({
  image
}: any) => {
  return (
      <div>
          <img src={image.ImageUrl} height={200} width={200}/>
      </div>
  );
};

export default ImagePreview;
