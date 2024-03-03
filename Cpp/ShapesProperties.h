typedef struct _FLIP_BOOL_H_V
{
   L_BOOL         bFlipH;
   L_BOOL         bFlipV;
}FLIPHV, * pFLIPHV;

typedef struct _SHAPE_TRANSFORM
{
   L_FLOAT  fRotation;
   L_BOOL   bFlipH;
   L_BOOL   bFlipV;
}SHAPETRANSFORM, * pSHAPETRANSFORM;

typedef struct _SHAPES_GROUP_TRANSFORM_PROPERTIES
{
   L_FLOAT        fRotation;
   L_POINTD       ptRotation;
   FLIPHV         bFlipHV;
   L_DOUBLE       dOffTop;
   L_DOUBLE       dOffLeft;
   L_DOUBLE       dOffWidth;
   L_DOUBLE       dOffHeight;
   L_DOUBLE       dChOffTop;
   L_DOUBLE       dChOffLeft;
   L_DOUBLE       dChOffWidth;
   L_DOUBLE       dChOffHeight;

}SHAPESGROUPTRANSFORMPROPERTIES, * pSHAPESGROUPTRANSFORMPROPERTIES;

typedef struct _SHAPES_GROUP_TRANSFORM_PROPERTIES_LIST
{
   SHAPESGROUPTRANSFORMPROPERTIES grpTransform;
   struct _SHAPES_GROUP_TRANSFORM_PROPERTIES_LIST *parent;
}SHAPESGROUPTRANSFORMPROPERTIESLIST, *pSHAPESGROUPTRANSFORMPROPERTIESLIST;
